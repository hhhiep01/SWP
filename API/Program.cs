using API.Middleware;
using Application;

using Application.Interface;
using Application.MyMapper;
using Application.Repository;
using Application.Services;
using Application.Validation;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Domain;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.Get<AppSetting>();
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddFluentValidationAutoValidation();



//config api 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseSqlServer(configuration!.ConnectionStrings.DefaultConnection);
    options.UseNpgsql(configuration!.ConnectionStrings.DefaultConnection);
    options.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddSwaggerGen
    (
    opt =>
    {
        opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization (\"bearer {token}\" ) ",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        opt.OperationFilter<SecurityRequirementsOperationFilter>();

    }

    );
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration!.SecretToken.Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                if (!string.IsNullOrEmpty(accessToken) &&
                    context.HttpContext.Request.Path.StartsWithSegments("/signalrHub"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
builder.Services.AddSingleton(configuration!);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<ISkinTestQuestionService, SkinTestQuestionService>();



builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<RegisterValidator>();


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(p => p.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.UseMiddleware<ValidationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



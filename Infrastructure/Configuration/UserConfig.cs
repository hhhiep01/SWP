using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Application.Services.AuthService;

namespace Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasOne(u => u.Cart)
            .WithOne(c => c.UserAccount)
            .HasForeignKey<Cart>(c => c.UserId);

            builder.HasMany(u => u.Orders)
           .WithOne(c => c.UserAccount)
           .HasForeignKey(c => c.UserAccountId);

            var user1 = CreatePasswordHash("User1");
            var user2 = CreatePasswordHash("User2");
            var employer = CreatePasswordHash("User3");
            var admin = CreatePasswordHash("Admin");

            builder.HasData
               (
                 new UserAccount
                 {
                     Id = 1,
                     //UserName = "User1",
                     PasswordHash = user1.PasswordHash,
                     PasswordSalt = user1.PasswordSalt,
                     LastName = "User1",
                     Role = Role.Customer,
                     Email = "User1@gmail.com",
                     IsEmailVerified = true
                 },
                 new UserAccount
                 {
                     Id = 2,
                     //UserName = "User2",
                     PasswordHash = user2.PasswordHash,
                     PasswordSalt = user2.PasswordSalt,
                     LastName = "User2",
                     Role = Role.Customer,
                     Email = "User2@gmail.com",
                     IsEmailVerified = true
                 },
                 new UserAccount
                 {
                     Id = 3,
                     //UserName = "User3",
                     PasswordHash = employer.PasswordHash,
                     PasswordSalt = employer.PasswordSalt,
                     LastName = "Employer",
                     Role = Role.Customer,
                     Email = "Employer@gmail.com",
                     IsEmailVerified = true
                 },
                 new UserAccount
                 {
                     Id = 4,
                     //UserName = "Admin",
                     PasswordHash = admin.PasswordHash,
                     PasswordSalt = admin.PasswordSalt,
                     LastName = "Admin",
                     Role = Role.Admin,
                     Email = "Admin@gmail.com",
                     IsEmailVerified = true
                 }
               );
        }



        private PasswordDTO CreatePasswordHash(string password)
        {
            PasswordDTO pass = new PasswordDTO();
            using (var hmac = new HMACSHA512())
            {
                pass.PasswordSalt = hmac.Key;
                pass.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return pass;
        }
    }
}

using Application;
using Application.Repository;
using Domain.Entity;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppDbContext _context;
        public IUserAccountRepository UserAccounts { get; }
        public IEmailVerificationRepository EmailVerifications { get; }
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public ICartRepository Carts { get; }
        public ICartItemRepository CartItems { get; }
        public IOrderRepository Orders { get; }
        public IOrderDetailRepository OrderDetails { get; }
        public IPaymentRepository Payments { get; }
        public ISkinTestAnswerRepository SkinTestAnswers { get; }
        public ISkinTestQuestionRepository SkinTestQuestions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserAccounts = new UserAccountRepository(context);
            EmailVerifications = new EmailVerificationRepository(context);
            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);
            Carts = new CartRepository(context);
            CartItems = new CartItemRepository(context);
            Orders = new OrderRepository(context);
            OrderDetails = new OrderDetailRepository(context);
            Payments = new PaymentRepository(context);
            SkinTestAnswers = new SkinTestAnswerRepository(context);
            SkinTestQuestions = new SkinTestQuestionRepository(context);

        }
        public async Task SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql) 
            // helper method thực thi 1 câu lệnh SQL, trả về 1 giá trị duy nhất dưới dạng kiểu dữ liệu chỉ định T
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand()) 
                // DBCommand thực thi 1 câu lệnh SQL
            {
                try
                {
                    // Đảm bảo rằng kết nối với cơ sở dữ liệu được mở trước khi thực thi
                    if (command.Connection!.State != System.Data.ConnectionState.Open) 
                        await command.Connection.OpenAsync();

                    command.CommandText = sql;

                    var result = await command.ExecuteScalarAsync(); 
                    //ExecuteScalarAsync trả về giá trị đầu tiên từ kết quả truy vấn
                    return (T)Convert.ChangeType(result, typeof(T));
                    //Chuyển đổi kết quả thành kiểu dữ liệu T
                }
                finally
                {
                    // Đóng kết nối dù thành công hay là lỗi
                    if (command.Connection!.State == System.Data.ConnectionState.Open)
                        await command.Connection.CloseAsync();
                }
            }
        }

        public async Task ExecuteRawSqlAsync(string sql)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    if (command.Connection.State != System.Data.ConnectionState.Open)
                    {
                        await command.Connection.OpenAsync();
                    }

                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
                finally
                {
                    if (command.Connection.State == System.Data.ConnectionState.Open)
                        await command.Connection.CloseAsync();
                }
            }
        }
    }
    
}

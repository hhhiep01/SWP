using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IUserAccountRepository UserAccounts { get; }
        public IEmailVerificationRepository EmailVerifications { get; }
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public ICartRepository Carts { get; }
        public ICartItemRepository CartItems { get;  }
        public IOrderRepository Orders { get; }
        public IOrderDetailRepository OrderDetails { get; }

        public Task SaveChangeAsync();
        Task<T> ExecuteScalarAsync<T>(string sql);
        Task ExecuteRawSqlAsync(string sql);
    }
}

using Application.Repository;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SkinTestQuestionRepository : GenericRepository<SkinTestQuestion>, ISkinTestQuestionRepository
    {
        public SkinTestQuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

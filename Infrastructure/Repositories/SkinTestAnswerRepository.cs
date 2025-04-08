﻿using Application.Repository;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SkinTestAnswerRepository : GenericRepository<SkinTestAnswer>, ISkinTestAnswerRepository
    {
        public SkinTestAnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
}

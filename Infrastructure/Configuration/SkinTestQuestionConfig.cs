using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class SkinTestQuestionConfig : IEntityTypeConfiguration<SkinTestQuestion>
    {
        public void Configure(EntityTypeBuilder<SkinTestQuestion> builder)
        {
            builder.HasMany(x => x.SkinTestAnswers)
                .WithOne(x => x.SkinTestQuestion)
                .HasForeignKey(x => x.SkinTestQuestionId);
        }
    }
}

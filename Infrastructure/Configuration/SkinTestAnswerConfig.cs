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
    public class SkinTestAnswerConfig : IEntityTypeConfiguration<SkinTestAnswer>
    {
        public void Configure(EntityTypeBuilder<SkinTestAnswer> builder)
        {
            builder.HasOne(x => x.SkinTestQuestion)
               .WithMany(x => x.SkinTestAnswers)
               .HasForeignKey(x => x.SkinTestQuestionId);
        }
    }
}

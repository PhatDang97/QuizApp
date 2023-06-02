using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Core.Data.Configurations
{
    public class QuestionGroupConfiguration : IEntityTypeConfiguration<QuestionGroup>
    {
        public void Configure(EntityTypeBuilder<QuestionGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.QuestionGroups)
                .HasForeignKey(x => x.TopicId)
                .HasConstraintName("FK_QuestionGroups_Topic")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

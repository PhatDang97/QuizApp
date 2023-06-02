using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(x => x.Option1)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Option2)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Option3)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Option4)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Option5)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Option6)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Answer)
                .IsRequired(false);

            builder.HasOne(x => x.QuestionGroup)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionGroupId)
                .HasConstraintName("FK_QuestionGroup_Topic")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

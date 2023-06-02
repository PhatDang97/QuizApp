using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Data.Configurations
{
    public class ParticipantResultConfiguration : IEntityTypeConfiguration<ParticipantResult>
    {
        public void Configure(EntityTypeBuilder<ParticipantResult> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Score)
                .IsRequired(false);

            builder.Property(x => x.TimeTaken)
                .IsRequired(false);

            builder.HasOne(x => x.Participant)
                .WithMany(x => x.ParticipantResults)
                .HasForeignKey(x => x.ParticipantId)
                .HasConstraintName("FK_ParticipantResults_Participant")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<QuestionGroup>()
                .WithOne(x => x.ParticipantResult)
                .HasForeignKey<ParticipantResult>(x => x.QuestionGroupId)
                .HasConstraintName("FK_ParticipantResults_QuestionGroup")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

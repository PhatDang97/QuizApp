using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Data.Configurations
{
    public class ResultConfiguration : IEntityTypeConfiguration<QuizResults>
    {
        public void Configure(EntityTypeBuilder<QuizResults> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ParticipantResult)
                .WithOne(x => x.Result)
                .HasForeignKey<QuizResults>(x => x.ParticipantResultId)
                .HasConstraintName("FK_ParticipantResult_Result");
        }
    }
}

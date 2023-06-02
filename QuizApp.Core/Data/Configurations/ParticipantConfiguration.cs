using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Data.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.UserName)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Score)
                .IsRequired(false);

            builder.Property(x => x.TimeTaken)
                .IsRequired(false);
        }
    }
}

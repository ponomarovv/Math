using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.TopicEntity;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        // builder.HasOne(t => t.Quiz)
        //     .WithMany(q => q.Topics)
        //     .HasForeignKey(t => t.QuizId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}


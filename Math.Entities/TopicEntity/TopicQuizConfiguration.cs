using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.TopicEntity;

public class TopicQuizConfiguration: IEntityTypeConfiguration<TopicQuiz>
{
    public void Configure(EntityTypeBuilder<TopicQuiz> builder)
    {
        builder.HasKey(tq => new { tq.TopicId, tq.QuizId });

        builder.HasOne(tq => tq.Topic)
            .WithMany(t => t.TopicQuizzes)
            .HasForeignKey(tq => tq.TopicId);

        builder.HasOne(tq => tq.Quiz)
            .WithMany(q => q.TopicQuizzes)
            .HasForeignKey(tq => tq.QuizId);

    }
}

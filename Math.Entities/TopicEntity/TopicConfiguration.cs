using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.TopicEntity;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasMany(t => t.TopicQuizzes)
            .WithOne(tq => tq.Topic)
            .HasForeignKey(tq => tq.TopicId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasOne(q => q.MainTopic)
            .WithMany(t => t.Quizzes)
            .HasForeignKey(q => q.MainTopicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.TopicQuizzes)
            .WithOne(tq => tq.Quiz)
            .HasForeignKey(tq => tq.QuizId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class TopicQuizConfiguration : IEntityTypeConfiguration<TopicQuiz>
{
    public void Configure(EntityTypeBuilder<TopicQuiz> builder)
    {
        builder.HasKey(tq => new { tq.TopicId, tq.QuizId });

        builder.HasOne(tq => tq.Topic)
            .WithMany(t => t.TopicQuizzes)
            .HasForeignKey(tq => tq.TopicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tq => tq.Quiz)
            .WithMany(q => q.TopicQuizzes)
            .HasForeignKey(tq => tq.QuizId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.TopicEntity;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder
            .HasOne(t => t.ParentTopic)
            .WithMany(t => t.ChildTopics)
            .HasForeignKey(t => t.ParentTopicId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasIndex(t => t.ParentTopicId)  // Add this line to create an index
            .HasDatabaseName("IX_ParentTopicId");

        builder
            .HasOne(t => t.ParentTopic)
            .WithMany(t => t.ChildTopics)
            .HasForeignKey(t => t.ParentTopicId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Topics_Topics_ParentTopicId");



        // Drop the existing foreign key constraint
        builder
            .HasOne(t => t.ParentTopic)
            .WithMany(t => t.ChildTopics)
            .HasForeignKey(t => t.ParentTopicId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Topics_Topics_ParentTopicId")
            .IsRequired(false);


    }
}

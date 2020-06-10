using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations
{
    class PostPublishConfiguration : IEntityTypeConfiguration<PostPublishEntity>
    {
        public void Configure(EntityTypeBuilder<PostPublishEntity> builder)
        {
            builder.HasKey(e => e.PostId);
            builder.Property(e => e.PostId).ValueGeneratedNever();
            builder.Property(e => e.LastModifiedUtc).HasColumnType("datetime");

            builder.Property(e => e.PubDateUtc)
                .HasColumnType("datetime");

            builder.Property(e => e.PublisherIp).HasMaxLength(64);
            builder.Property(e => e.ContentLanguageCode).HasMaxLength(8);

            builder.HasOne(d => d.Post)
                .WithOne(p => p.PostPublish)
                .HasForeignKey<PostPublishEntity>(d => d.PostId)
                .HasConstraintName("FK_PostPublish_Post");
        }
    }
}
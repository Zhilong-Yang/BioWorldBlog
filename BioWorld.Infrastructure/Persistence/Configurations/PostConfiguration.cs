using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.CommentEnabled);
            builder.Property(e => e.ContentAbstract).HasMaxLength(1024);

            builder.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            builder.Property(e => e.PostContent);

            builder.Property(e => e.Slug).HasMaxLength(128);
            builder.Property(e => e.Title).HasMaxLength(128);
        }
    }
}
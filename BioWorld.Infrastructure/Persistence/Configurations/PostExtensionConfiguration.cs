using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations
{
    class PostExtensionConfiguration : IEntityTypeConfiguration<PostExtensionEntity>
    {
        public void Configure(EntityTypeBuilder<PostExtensionEntity> builder)
        {
            builder.HasKey(e => e.PostId);
            builder.Property(e => e.PostId).ValueGeneratedNever();

            builder.HasOne(d => d.Post)
                .WithOne(p => p.PostExtension)
                .HasForeignKey<PostExtensionEntity>(d => d.PostId)
                .HasConstraintName("FK_PostExtension_Post");
        }
    }
}
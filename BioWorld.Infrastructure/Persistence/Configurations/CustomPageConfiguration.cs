using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations
{
    public class CustomPageConfiguration : IEntityTypeConfiguration<CustomPageEntity>
    {
        public void Configure(EntityTypeBuilder<CustomPageEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Title).HasMaxLength(128);
            builder.Property(e => e.RouteName).HasMaxLength(128);
        }
    }
}
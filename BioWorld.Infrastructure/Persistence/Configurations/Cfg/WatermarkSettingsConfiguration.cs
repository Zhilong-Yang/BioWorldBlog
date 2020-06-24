using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class WatermarkSettingsConfiguration : IEntityTypeConfiguration<WatermarkSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<WatermarkSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.IsEnabled).IsRequired();
            builder.Property(e => e.KeepOriginImage).IsRequired();
            builder.Property(e => e.FontSize).IsRequired();
            builder.Property(e => e.WatermarkText).HasMaxLength(32).IsRequired();
        }
    }
}
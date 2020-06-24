using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class GeneralSettingsConfiguration : IEntityTypeConfiguration<GeneralSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<GeneralSettingsEntity> builder)
        {
            builder.Property(e => e.MetaKeyword).HasMaxLength(1024);
            builder.Property(e => e.MetaDescription).HasMaxLength(1024);
            builder.Property(e => e.LogoText).HasMaxLength(16);
            builder.Property(e => e.Copyright).HasMaxLength(64);
            builder.Property(e => e.SiteTitle).HasMaxLength(16);
            builder.Property(e => e.OwnerName).HasMaxLength(32);
            builder.Property(e => e.Description).HasMaxLength(256);
            builder.Property(e => e.ShortDescription).HasMaxLength(32);
            builder.Property(e => e.SideBarCustomizedHtmlPitch).HasMaxLength(2048);
            builder.Property(e => e.FooterCustomizedHtmlPitch).HasMaxLength(4096);
            builder.Property(e => e.TimeZoneId).HasMaxLength(64);
            builder.Property(e => e.ThemeFileName).HasMaxLength(32);

            builder.Property(e => e.CanonicalPrefix);
            builder.Property(e => e.TimeZoneUtcOffset);
            builder.Property(e => e.SiteIconBase64);
            builder.Property(e => e.AvatarBase64);
            builder.Property(e => e.AutoDarkLightTheme);
        }
    }
}
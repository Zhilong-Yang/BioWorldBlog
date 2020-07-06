using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class GeneralSettingsConfiguration : IEntityTypeConfiguration<GeneralSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<GeneralSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.MetaKeyword).HasMaxLength(1024).IsRequired();
            builder.Property(e => e.MetaDescription).HasMaxLength(1024).IsRequired();
            builder.Property(e => e.LogoText).HasMaxLength(16).IsRequired();
            builder.Property(e => e.Copyright).HasMaxLength(64).IsRequired();
            builder.Property(e => e.SiteTitle).HasMaxLength(16).IsRequired();
            builder.Property(e => e.OwnerName).HasMaxLength(32).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(256).IsRequired();
            builder.Property(e => e.ShortDescription).HasMaxLength(32).IsRequired();
            builder.Property(e => e.SideBarCustomizedHtmlPitch).HasMaxLength(2048);
            builder.Property(e => e.FooterCustomizedHtmlPitch).HasMaxLength(4096);
            builder.Property(e => e.TimeZoneId).HasMaxLength(64);
            builder.Property(e => e.ThemeFileName).HasMaxLength(32).HasDefaultValue("word-blue.css");

            builder.Property(e => e.CanonicalPrefix);
            builder.Property(e => e.TimeZoneUtcOffset);
            builder.Property(e => e.SiteIconBase64).HasDefaultValue(string.Empty);
            builder.Property(e => e.AvatarBase64).HasDefaultValue(string.Empty);
            builder.Property(e => e.AutoDarkLightTheme);
        }
    }
}
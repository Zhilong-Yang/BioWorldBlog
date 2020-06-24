using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class FeedSettingsConfiguration : IEntityTypeConfiguration<FeedSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<FeedSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.RssItemCount).HasDefaultValue(20);
            builder.Property(e => e.RssCopyright).HasMaxLength(64).IsRequired();
            builder.Property(e => e.RssDescription).HasMaxLength(512).IsRequired();
            builder.Property(e => e.RssGeneratorName).HasMaxLength(64).IsRequired();
            builder.Property(e => e.RssTitle).HasMaxLength(64).IsRequired();
            builder.Property(e => e.AuthorName).HasMaxLength(32).IsRequired();
            builder.Property(e => e.UseFullContent);
        }
    }
}
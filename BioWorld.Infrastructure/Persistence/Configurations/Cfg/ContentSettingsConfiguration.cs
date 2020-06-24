using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class ContentSettingsConfiguration : IEntityTypeConfiguration<ContentSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<ContentSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.DisharmonyWords).HasMaxLength(2048).HasDefaultValue(string.Empty).IsRequired();
            builder.Property(e => e.EnableComments).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.RequireCommentReview).IsRequired();
            builder.Property(e => e.EnableWordFilter).IsRequired();
            builder.Property(e => e.UseFriendlyNotFoundImage).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.PostListPageSize).HasDefaultValue(10).IsRequired();
            builder.Property(e => e.HotTagAmount).HasDefaultValue(10).IsRequired();
            builder.Property(e => e.EnableGravatar).IsRequired();
            builder.Property(e => e.ShowCalloutSection);
            builder.Property(e => e.CalloutSectionHtmlPitch).HasMaxLength(2048);
            builder.Property(e => e.ShowPostFooter);
            builder.Property(e => e.PostFooterHtmlPitch);
        }
    }
}
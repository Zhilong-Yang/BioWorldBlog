using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class NotificationSettingsConfiguration : IEntityTypeConfiguration<NotificationSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.EnableEmailSending);
            builder.Property(e => e.SendEmailOnCommentReply);
            builder.Property(e => e.SendEmailOnNewComment);
            builder.Property(e => e.AdminEmail).HasMaxLength(64).IsRequired();
            builder.Property(e => e.EmailDisplayName).HasMaxLength(64).IsRequired();
        }
    }
}
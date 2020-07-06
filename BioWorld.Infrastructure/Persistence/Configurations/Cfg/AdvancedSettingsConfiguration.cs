using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class AdvancedSettingsConfiguration : IEntityTypeConfiguration<AdvancedSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<AdvancedSettingsEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.DNSPrefetchEndpoint).HasMaxLength(128);
            builder.Property(e => e.RobotsTxtContent).HasMaxLength(1024);
            builder.Property(e => e.EnablePingBackSend);
            builder.Property(e => e.EnablePingBackReceive);
        }
    }
}
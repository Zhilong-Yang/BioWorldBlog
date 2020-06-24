using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class NotificationSettingsConfiguration : IEntityTypeConfiguration<NotificationSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

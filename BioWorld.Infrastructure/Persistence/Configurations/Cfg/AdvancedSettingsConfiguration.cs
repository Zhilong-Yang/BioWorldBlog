using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class AdvancedSettingsConfiguration : IEntityTypeConfiguration<AdvancedSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<AdvancedSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

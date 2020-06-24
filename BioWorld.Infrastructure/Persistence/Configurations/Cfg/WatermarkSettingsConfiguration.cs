using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class WatermarkSettingsConfiguration : IEntityTypeConfiguration<WatermarkSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<WatermarkSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

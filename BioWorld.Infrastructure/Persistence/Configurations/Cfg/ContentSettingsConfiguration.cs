using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class ContentSettingsConfiguration : IEntityTypeConfiguration<ContentSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<ContentSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class FeedSettingsConfiguration : IEntityTypeConfiguration<FeedSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<FeedSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

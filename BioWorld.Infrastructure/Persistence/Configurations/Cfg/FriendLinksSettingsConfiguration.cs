using System;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations.Cfg
{
    public class FriendLinksSettingsConfiguration : IEntityTypeConfiguration<FriendLinksSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<FriendLinksSettingsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}

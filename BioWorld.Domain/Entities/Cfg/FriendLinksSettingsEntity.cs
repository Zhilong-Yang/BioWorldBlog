using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class FriendLinksSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public bool ShowFriendLinksSection { get; set; }
    }
}
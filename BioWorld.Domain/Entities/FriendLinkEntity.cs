using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class FriendLinkEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }
}
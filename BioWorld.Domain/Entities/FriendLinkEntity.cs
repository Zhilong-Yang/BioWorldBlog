using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Domain.Entities
{
    public class FriendLinkEntity: AuditableEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }
}

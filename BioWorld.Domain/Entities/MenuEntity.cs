using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class MenuEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsOpenInNewTab { get; set; }
    }
}
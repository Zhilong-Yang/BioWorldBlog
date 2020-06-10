using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class CustomPageEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RouteName { get; set; }
        public string HtmlContent { get; set; }
        public string CssContent { get; set; }
        public bool HideSidebar { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
    }
}
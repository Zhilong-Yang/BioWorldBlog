using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Domain.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }
    }
}

using System;

namespace BioWorld.Application.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }
    }
}
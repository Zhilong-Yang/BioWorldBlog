using System;

namespace BioWorld.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }
    }
}
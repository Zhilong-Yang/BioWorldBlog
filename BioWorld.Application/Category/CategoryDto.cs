using System;
using System.Collections.Generic;

namespace BioWorld.Application.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }
    }

    public class CategoryJsonDto
    {
        public IReadOnlyList<CategoryDto> CategoryList { get; set; }

        public CategoryJsonDto(IReadOnlyList<CategoryDto> categoryList)
        {
            CategoryList = categoryList;
        }
    }
}
using System;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public class CategorySpec : BaseSpecification<CategoryEntity>
    {
        public CategorySpec(string categoryName) : base(c => c.RouteName == categoryName)
        {
        }

        public CategorySpec(Guid categoryId) : base(c => c.Id == categoryId)
        {
        }
    }
}
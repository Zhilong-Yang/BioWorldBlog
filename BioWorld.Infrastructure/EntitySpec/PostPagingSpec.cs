﻿using System;
using System.Linq;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public class PostPagingSpec : BaseSpecification<PostEntity>
    {
        public PostPagingSpec(int pageSize, int pageIndex, Guid? categoryId = null)
            : base(p => !p.PostPublish.IsDeleted &&
                        p.PostPublish.IsPublished &&
                        (categoryId == null || p.PostCategory.Select(c => c.CategoryId).Contains(categoryId.Value)))
        {
            var startRow = (pageIndex - 1) * pageSize;

            //AddInclude(post => post
            //    .Include(p => p.PostPublish)
            //    .Include(p => p.PostExtension)
            //    .Include(p => p.PostTag)
            //    .ThenInclude(pt => pt.Tag));
            ApplyPaging(startRow, pageSize);
            ApplyOrderByDescending(p => p.PostPublish.PubDateUtc);
        }
    }
}
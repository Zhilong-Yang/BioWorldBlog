using System;
using System.Linq;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Infrastructure.EntitySpec
{
    public sealed class CommentSpec : BaseSpecification<CommentEntity>
    {
        public CommentSpec(int pageSize, int pageIndex) : base(c => true)
        {
            var startRow = (pageIndex - 1) * pageSize;

            AddInclude(comment => comment
                .Include(c => c.Post)
                .Include(c => c.CommentReply));
            ApplyOrderByDescending(p => p.CreateOnUtc);
            ApplyPaging(startRow, pageSize);
        }

        public CommentSpec(Guid[] ids) : base(c => ids.Contains(c.Id))
        {
        }

        public CommentSpec(Guid postId) : base(c => c.PostId == postId &&
                                                    c.IsApproved)
        {
            AddInclude(comments => comments.Include(c => c.CommentReply));
        }
    }
}
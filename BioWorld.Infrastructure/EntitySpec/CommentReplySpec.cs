using System;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public class CommentReplySpec : BaseSpecification<CommentReplyEntity>
    {
        public CommentReplySpec(Guid commentId) : base(cr => cr.CommentId == commentId)
        {
        }
    }
}
using System;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public class FriendLinkSpec : BaseSpecification<FriendLinkEntity>
    {
        public FriendLinkSpec(Guid id) : base(f => f.Id == id)
        {
        }
    }
}
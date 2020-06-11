using System;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public class PingbackHistorySpec : BaseSpecification<PingbackHistoryEntity>
    {
        public PingbackHistorySpec(Guid id) : base(p => p.Id == id)
        {
        }
    }
}
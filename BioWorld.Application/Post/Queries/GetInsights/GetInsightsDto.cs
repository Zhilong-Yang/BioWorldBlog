﻿using System;
using System.Collections.Generic;

namespace BioWorld.Application.Post.Queries.GetInsights
{
    public class GetInsightsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PubDateUtc { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public int? Revision { get; set; }
        public bool IsPublished { get; set; }
        public int Hits { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class GetInsightsJsonDto
    {
        public IReadOnlyList<GetInsightsDto> InsightList { get; set; }

        public GetInsightsJsonDto(IReadOnlyList<GetInsightsDto> insightList)
        {
            InsightList = insightList;
        }
    }
}
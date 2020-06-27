using System;
using System.Collections.Generic;

namespace BioWorld.Application.CustomPage.Queries.GetCustomPageListSegment
{
    public class CustomPageSegmentDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string RouteName { get; set; }

        public bool IsPublished { get; set; }

        public DateTime CreateOnUtc { get; set; }
    }

    public class CustomPageSegmentJsonDto
    {
        public IReadOnlyList<CustomPageSegmentDto> CustomPageList { get; set; }

        public CustomPageSegmentJsonDto(IReadOnlyList<CustomPageSegmentDto> customPageList)
        {
            CustomPageList = customPageList;
        }
    }
}

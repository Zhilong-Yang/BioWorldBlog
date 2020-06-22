using System;
using System.Collections.Generic;

namespace BioWorld.Application.FriendLink
{
    public class FriendLinkDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }

    public class FriendLinkJsonDto
    {
        public IReadOnlyList<FriendLinkDto> FriendLinkList { get; set; }

        public FriendLinkJsonDto(IReadOnlyList<FriendLinkDto> friendLinkList)
        {
            FriendLinkList = friendLinkList;
        }
    }
}
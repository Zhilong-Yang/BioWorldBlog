using System;
using System.Collections.Generic;

namespace BioWorld.Application.Menu
{
    public class MenuDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsOpenInNewTab { get; set; }

        public MenuDto()
        {
            Icon = "icon-file-text2";
        }
    }

    public class MenuJsonDto
    {
        public IReadOnlyList<MenuDto> MenuList { get; set; }

        public MenuJsonDto(IReadOnlyList<MenuDto> menuList)
        {
            MenuList = menuList;
        }
    }
}
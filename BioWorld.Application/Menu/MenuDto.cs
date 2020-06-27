﻿using System;

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
}

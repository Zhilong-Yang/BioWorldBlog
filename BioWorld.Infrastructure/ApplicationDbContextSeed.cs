﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BioWorld.Domain.Entities;
using BioWorld.Domain.Entities.Cfg;
using BioWorld.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace BioWorld.Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
                {UserName = "administrator@localhost", Email = "administrator@localhost"};

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            Guid newCategoryId0  = Guid.Parse("9710daba-ae1b-462c-9252-8eacf90f45a8");
            Guid newCategoryId1  = Guid.Parse("74659a50-12da-4a56-95af-7e47ee662020");
            Guid newCategoryId2  = Guid.Parse("5543ccd9-d51e-4430-b75a-5f4c2abeef81");
            Guid newCategoryId3  = Guid.Parse("75b53184-1e18-4203-80c0-ad3ad828d24e");
            Guid newCategoryId4  = Guid.Parse("dfd67574-0511-47b4-9f55-f40a71f0ac06");
            Guid newCategoryId5  = Guid.Parse("bfab933e-ac67-41c4-8a78-18cc2ec81f31");
            Guid newCategoryId6  = Guid.Parse("48ed7a23-0e6d-4ad8-b36b-b364c1232c89");
            Guid newCategoryId7  = Guid.Parse("c0ccc720-2375-4a10-8bc8-8ea995778ad0");
            Guid newCategoryId8  = Guid.Parse("f604ef1f-772d-4c08-a245-c4d3c4985f92");
            Guid newCategoryId9  = Guid.Parse("20749667-49cd-4566-a5f8-14848ab0f1a4");
            Guid newCategoryId10 = Guid.Parse("cce39d7a-a62a-47a9-a1bb-b26e6d4417c6");
            Guid newCategoryId11 = Guid.Parse("0d358920-8d7f-4858-9f52-f0c7a7d4fe4e");

            // Seed, if necessary
            if (!context.Category.Any())
            {
                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId0,
                    DisplayName = "ASP.NET",
                    Note = "ASP.NET Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId1,
                    DisplayName = "C# and .NET",
                    Note = "C# and .NET Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId2,
                    DisplayName = "Data Platform",
                    Note = "Data Platform Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId3,
                    DisplayName = "DevOps",
                    Note = "DevOps Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId4,
                    DisplayName = "Events",
                    Note = "Events Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId5,
                    DisplayName = "IIS",
                    Note = "IIS Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId6,
                    DisplayName = "Internet of Things",
                    Note = "Internet of Things Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId7,
                    DisplayName = "Microsoft Azure",
                    Note = "Microsoft Azure Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId8,
                    DisplayName = "Software and Application",
                    Note = "Software and Application Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId9,
                    DisplayName = "Web Development",
                    Note = "Web Development Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId10,
                    DisplayName = "Windows Development",
                    Note = "Windows Development Category",
                    RouteName = "default"
                });

                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId11,
                    DisplayName = "Work",
                    Note = "Work Category",
                    RouteName = "default"
                });
            }

            if (!context.Tag.Any())
            {
                context.Tag.Add(new TagEntity()
                {
                    //Id = 1,
                    DisplayName = ".NET Core",
                    NormalizedName = "dotnet-core"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 2,
                    DisplayName = "Azure",
                    NormalizedName = "azure"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 3,
                    DisplayName = "ASP.NET",
                    NormalizedName = "aspdotnet"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 4,
                    DisplayName = "UWP",
                    NormalizedName = "uwp"
                });
                context.Tag.Add(new TagEntity()
                {
                    //Id = 5,
                    DisplayName = "Windows 10",
                    NormalizedName = "windows-10"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 6,
                    DisplayName = "Windows Phone",
                    NormalizedName = "windows-phone"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 7,
                    DisplayName = "Visual Studio",
                    NormalizedName = "visual-studio"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 8,
                    DisplayName = "Raspberry Pi",
                    NormalizedName = "raspberry-pi"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 9,
                    DisplayName = "IoT",
                    NormalizedName = "iot"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 10,
                    DisplayName = "IIS",
                    NormalizedName = "iis"
                });
            }

            if (!context.FriendLink.Any())
            {
                context.Add(new FriendLinkEntity
                {
                    Id = Guid.Parse("f4079a57-3d22-4ab8-9fdf-25c31f4f5644"),
                    LinkUrl = "https://zhilong.yang",
                    Title = "zhilong.yang"
                });
            }

            if (!context.Menu.Any())
            {
                context.Add(new MenuEntity
                {
                    Id = Guid.Parse("06d83988-c254-43b9-9220-d3a4a862fae8"),
                    Title = "About",
                    Url = "/page/about",
                    Icon = "icon-star-full",
                    DisplayOrder = 0,
                    IsOpenInNewTab = false
                });
            }

            Guid newPostId0 = Guid.Parse("4886ec88-fc7b-4338-9fd2-56411187a7f7");
            Guid newPostId1 = Guid.Parse("1ed57ed3-220f-4872-a0a2-e439442274d3");

            if (!context.Post.Any())
            {
                context.Add(new PostEntity
                {
                    Id = newPostId0,
                    Title = "Welcome to BioWorld",
                    Slug = "welcome-to-bioworld",
                    PostContent =
                        "Bioworld is the new blog system for https://zhilong.yang. It is a complete rewrite of the old system using .NET Core and runs on Microsoft Azure.",
                    CommentEnabled = true,
                    CreateOnUtc = DateTime.UtcNow,
                    ContentAbstract = "new blog system",
                    PostExtension = new PostExtensionEntity
                    {
                        PostId = newPostId0,
                        Hits = 1024,
                        Likes = 512
                    }
                });

                context.Add(new PostEntity
                {
                    Id = newPostId1,
                    Title = "Solving Azure AD Sign In Failure with Azure Front Door",
                    Slug = "solving-azure-ad-sign-in-failure-with-azure-front-door",
                    PostContent =
                        "\u003c\u0070\u003e\u0054\u006f\u0064\u0061\u0079\u0020\u0049\u0020\u0061\u006d\u0020\u006d\u0069\u0067\u0072\u0061\u0074\u0069\u006e\u0067\u0020\u006d\u0079\u0020\u0062\u006c\u006f\u0067\u0020\u0074\u006f\u0020\u0075\u0073\u0065\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u0020\u0077\u0068\u0069\u0063\u0068\u0020\u0049\u0020\u0068\u0061\u0076\u0065\u0020\u0069\u006e\u0074\u0072\u006f\u0064\u0075\u0063\u0065\u0064\u0020\u0069\u006e\u0020\u003c\u0061\u0020\u0068\u0072\u0065\u0066\u003d\u0022\u002f\u0070\u006f\u0073\u0074\u002f\u0032\u0030\u0031\u0039\u002f\u0031\u0031\u002f\u0032\u0032\u002f\u0061\u002d\u0062\u0072\u0069\u0065\u0066\u002d\u0069\u006e\u0074\u0072\u006f\u0064\u0075\u0063\u0074\u0069\u006f\u006e\u002d\u0066\u006f\u0072\u002d\u0061\u007a\u0075\u0072\u0065\u002d\u0066\u0072\u006f\u006e\u0074\u002d\u0064\u006f\u006f\u0072\u0022\u0020\u0074\u0061\u0072\u0067\u0065\u0074\u003d\u0022\u005f\u0062\u006c\u0061\u006e\u006b\u0022\u0020\u0072\u0065\u006c\u003d\u0022\u006e\u006f\u006f\u0070\u0065\u006e\u0065\u0072\u0022\u003e\u0061\u0020\u0070\u0072\u0065\u0076\u0069\u006f\u0075\u0073\u0020\u0062\u006c\u006f\u0067\u0020\u0070\u006f\u0073\u0074\u003c\u002f\u0061\u003e\u0020\u006c\u0061\u0073\u0074\u0020\u0079\u0065\u0061\u0072\u002e\u0020\u0045\u0076\u0065\u0072\u0079\u0074\u0068\u0069\u006e\u0067\u0020\u0077\u0065\u006e\u0074\u0020\u0077\u0065\u006c\u006c\u0020\u0065\u0078\u0063\u0065\u0070\u0074\u0020\u0066\u006f\u0072\u0020\u0074\u0068\u0065\u0020\u0062\u006c\u006f\u0067\u0020\u0061\u0064\u006d\u0069\u006e\u0020\u0073\u0069\u0067\u006e\u0020\u0069\u006e\u002e\u0020\u0049\u0020\u0063\u006f\u006e\u0066\u0069\u0067\u0075\u0072\u0065\u0064\u0020\u006d\u0079\u0020\u0062\u006c\u006f\u0067\u0020\u0074\u006f\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0044\u0020\u0061\u0073\u0020\u0053\u0053\u004f\u002e\u0020\u0042\u0075\u0074\u0020\u0061\u0066\u0074\u0065\u0072\u0020\u0049\u0020\u0070\u0075\u0074\u0020\u0074\u0068\u0065\u0020\u0062\u006c\u006f\u0067\u0020\u0062\u0065\u0068\u0069\u006e\u0064\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u0020\u0077\u0069\u0074\u0068\u0020\u006d\u0079\u0020\u0063\u0075\u0073\u0074\u006f\u006d\u0020\u0064\u006f\u006d\u0061\u0069\u006e\u002c\u0020\u004f\u0049\u0044\u0043\u0020\u0052\u0065\u0064\u0069\u0072\u0065\u0063\u0074\u0020\u0055\u0052\u004c\u0020\u006a\u0075\u0073\u0074\u0020\u0062\u006c\u006f\u0077\u0020\u0075\u0070\u002e\u003c\u002f\u0070\u003e\u000a\u003c\u0068\u0035\u003e\u004f\u0049\u0044\u0043\u0020\u0052\u0065\u0064\u0069\u0072\u0065\u0063\u0074\u0069\u006f\u006e\u0020\u0046\u0061\u0069\u006c\u0075\u0072\u0065\u003c\u002f\u0068\u0035\u003e\u000a\u003c\u0068\u0072\u003e\u000a\u003c\u0070\u003e\u0057\u0068\u0065\u006e\u0020\u0049\u0020\u0074\u0072\u0069\u0065\u0064\u0020\u0074\u006f\u0020\u0073\u0069\u0067\u006e\u0020\u0069\u006e\u002c\u0020\u0074\u0068\u0065\u0020\u0072\u0065\u0064\u0069\u0072\u0065\u0063\u0074\u0069\u006f\u006e\u0020\u0055\u0052\u004c\u0020\u0073\u0075\u0064\u0064\u0065\u006e\u006c\u0079\u0020\u0077\u0065\u006e\u0074\u0020\u0074\u006f\u0020\u003c\u0063\u006f\u0064\u0065\u003e\u0068\u0074\u0074\u0070\u0073\u003a\u002f\u002f\u0065\u0064\u0069\u0077\u0061\u006e\u0067\u002d\u0077\u0065\u0062\u002e\u0061\u007a\u0075\u0072\u0065\u0077\u0065\u0062\u0073\u0069\u0074\u0065\u0073\u002e\u006e\u0065\u0074\u002f\u0073\u0069\u0067\u006e\u0069\u006e\u002d\u006f\u0069\u0064\u0063\u003c\u002f\u0063\u006f\u0064\u0065\u003e\u0020\u0061\u006e\u0064\u0020\u0062\u006c\u006f\u0077\u0073\u0020\u0074\u0068\u0065\u0020\u0061\u0070\u0070\u006c\u0069\u0063\u0061\u0074\u0069\u006f\u006e\u0020\u0074\u006f\u0020\u0068\u0065\u006c\u006c\u002e\u0020\u0054\u0068\u0069\u0073\u0020\u0069\u0073\u0020\u0074\u0068\u0065\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0070\u0070\u0020\u0053\u0065\u0072\u0076\u0069\u0063\u0065\u0020\u0064\u0065\u0066\u0061\u0075\u006c\u0074\u0020\u0064\u006f\u006d\u0061\u0069\u006e\u0020\u0077\u0068\u0069\u0063\u0068\u0020\u0069\u0073\u0020\u0061\u006c\u0073\u006f\u0020\u0063\u006f\u006e\u0066\u0069\u0067\u0075\u0072\u0065\u0064\u0020\u0061\u0073\u0020\u0062\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0070\u006f\u006f\u006c\u0020\u0069\u006e\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u002e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u003c\u0069\u006d\u0067\u0020\u0073\u0072\u0063\u003d\u0022\u002f\u0075\u0070\u006c\u006f\u0061\u0064\u0073\u002f\u0069\u006d\u0067\u002d\u0037\u0030\u0035\u0063\u0031\u0033\u0061\u0033\u002d\u0035\u0061\u0064\u0034\u002d\u0034\u0061\u0063\u0038\u002d\u0061\u0064\u0061\u0037\u002d\u0065\u0034\u0033\u0065\u0037\u0062\u0037\u0064\u0034\u0039\u0062\u0032\u002e\u0070\u006e\u0067\u0022\u0020\u0061\u006c\u0074\u003d\u0022\u0022\u0020\u006c\u006f\u0061\u0064\u0069\u006e\u0067\u003d\u0022\u006c\u0061\u007a\u0079\u0022\u0020\u0063\u006c\u0061\u0073\u0073\u003d\u0022\u0069\u006d\u0067\u002d\u0066\u006c\u0075\u0069\u0064\u0020\u0069\u006d\u0067\u002d\u0074\u0068\u0075\u006d\u0062\u006e\u0061\u0069\u006c\u0022\u003e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u004e\u006f\u0072\u006d\u0061\u006c\u006c\u0079\u002c\u0020\u0069\u0074\u0020\u0073\u0068\u006f\u0075\u006c\u0064\u0020\u0062\u0065\u0020\u003c\u0063\u006f\u0064\u0065\u003e\u0068\u0074\u0074\u0070\u0073\u003a\u002f\u002f\u0065\u0064\u0069\u002e\u0077\u0061\u006e\u0067\u002f\u0073\u0069\u0067\u006e\u0069\u006e\u002d\u006f\u0069\u0064\u0063\u003c\u002f\u0063\u006f\u0064\u0065\u003e\u002e\u0026\u006e\u0062\u0073\u0070\u003b\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0054\u0068\u0065\u0020\u0072\u0065\u0061\u0073\u006f\u006e\u0020\u0077\u0068\u0079\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0044\u0020\u0077\u0069\u006c\u006c\u0020\u0072\u0065\u0064\u0069\u0072\u0065\u0063\u0074\u0020\u0062\u0061\u0063\u006b\u0020\u0074\u006f\u0020\u006d\u0079\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0070\u0070\u0020\u0053\u0065\u0072\u0076\u0069\u0063\u0065\u0020\u0064\u006f\u006d\u0061\u0069\u006e\u0020\u0069\u006e\u0073\u0074\u0065\u0061\u0064\u0020\u006f\u0066\u0020\u006d\u0079\u0020\u0063\u0075\u0073\u0074\u006f\u006d\u0020\u0064\u006f\u006d\u0061\u0069\u006e\u0020\u0069\u0073\u0020\u0062\u0065\u0063\u0061\u0075\u0073\u0065\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u0020\u0069\u0073\u0020\u006a\u0075\u0073\u0074\u0020\u0064\u006f\u0069\u006e\u0067\u0020\u0061\u0020\u0073\u0069\u006d\u0070\u006c\u0065\u0020\u0066\u006f\u0072\u0077\u0061\u0072\u0064\u0020\u0066\u006f\u0072\u0020\u0069\u006e\u0063\u006f\u006d\u0069\u006e\u0067\u0020\u0072\u0065\u0071\u0075\u0065\u0073\u0074\u0073\u002e\u0020\u0057\u0068\u0065\u006e\u0020\u0074\u0068\u0065\u0020\u0072\u0065\u0071\u0075\u0065\u0073\u0074\u0073\u0020\u0068\u0069\u0074\u0020\u0074\u0068\u0065\u0020\u0041\u0070\u0070\u0020\u0053\u0065\u0072\u0076\u0069\u0063\u0065\u002c\u0020\u0069\u0074\u0020\u0073\u0065\u0065\u0073\u0020\u0074\u0068\u0065\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u0020\u0061\u0073\u0020\u003c\u0063\u006f\u0064\u0065\u003e\u002a\u002e\u0061\u007a\u0075\u0072\u0065\u0077\u0065\u0062\u0073\u0069\u0074\u0065\u0073\u002e\u006e\u0065\u0074\u003c\u002f\u0063\u006f\u0064\u0065\u003e\u002c\u0020\u0074\u0068\u0065\u006e\u002c\u0020\u0069\u0074\u0020\u0070\u0061\u0073\u0073\u0020\u0074\u0068\u0065\u0020\u0069\u006e\u0066\u006f\u0072\u006d\u0061\u0074\u0069\u006f\u006e\u0020\u0074\u006f\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0044\u002c\u0020\u0077\u0068\u0069\u0063\u0068\u0020\u0077\u0069\u006c\u006c\u0020\u0075\u0073\u0065\u0020\u0074\u0068\u0065\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u0020\u0061\u0073\u0020\u004f\u0049\u0044\u0043\u0020\u0072\u0065\u0064\u0069\u0072\u0065\u0063\u0074\u0069\u006f\u006e\u0020\u0055\u0052\u004c\u002c\u0020\u0069\u0074\u0020\u0063\u0065\u0072\u0074\u0061\u0069\u006e\u006c\u0079\u0020\u0069\u0073\u0020\u006e\u006f\u0074\u0020\u006d\u0079\u0020\u0063\u0075\u0073\u0074\u006f\u006d\u0020\u0064\u006f\u006d\u0061\u0069\u006e\u002c\u0020\u0073\u006f\u0020\u0074\u0068\u0065\u0020\u0073\u0069\u0067\u006e\u0020\u0069\u006e\u0020\u0077\u006f\u0075\u006c\u0064\u0020\u0066\u0061\u0069\u006c\u002e\u0026\u006e\u0062\u0073\u0070\u003b\u003c\u002f\u0070\u003e\u000a\u003c\u0068\u0035\u003e\u0053\u006f\u006c\u0075\u0074\u0069\u006f\u006e\u003c\u002f\u0068\u0035\u003e\u000a\u003c\u0068\u0072\u003e\u000a\u003c\u0070\u003e\u0054\u0068\u0065\u0020\u0070\u0072\u006f\u0062\u006c\u0065\u006d\u0020\u0069\u0073\u0020\u0074\u0068\u0061\u0074\u0020\u0077\u0065\u0020\u0064\u006f\u006e\u0027\u0074\u0020\u0068\u0061\u0076\u0065\u0020\u0061\u0020\u0063\u006f\u0072\u0072\u0065\u0063\u0074\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u0020\u0074\u006f\u0020\u0070\u0061\u0073\u0073\u0020\u0074\u006f\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0044\u002c\u0020\u0073\u006f\u0020\u0068\u006f\u0077\u0020\u0063\u0061\u006e\u0020\u0077\u0065\u0020\u0074\u0065\u006c\u006c\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u0020\u0074\u006f\u0020\u0075\u0073\u0065\u0020\u0061\u0020\u0063\u006f\u0072\u0072\u0065\u0063\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u003f\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0041\u0063\u0074\u0075\u0061\u006c\u006c\u0079\u0020\u0069\u0074\u0027\u0073\u0020\u0076\u0065\u0072\u0079\u0020\u0073\u0069\u006d\u0070\u006c\u0065\u002e\u0020\u0042\u0079\u0020\u0064\u0065\u0066\u0061\u0075\u006c\u0074\u002c\u0020\u0077\u0068\u0065\u006e\u0020\u0077\u0065\u0020\u0061\u0064\u0064\u0020\u0061\u0020\u0062\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0070\u006f\u006f\u006c\u0020\u0069\u006e\u0074\u006f\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0046\u0072\u006f\u006e\u0074\u0020\u0044\u006f\u006f\u0072\u0020\u0066\u006f\u0072\u0020\u0061\u006e\u0020\u0041\u0070\u0070\u0020\u0053\u0065\u0072\u0076\u0069\u0063\u0065\u002c\u0020\u0074\u0068\u0065\u0072\u0065\u0020\u0069\u0073\u0020\u0061\u0020\u0022\u003c\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0042\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u003c\u002f\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0022\u0020\u0066\u0069\u0065\u006c\u0064\u0020\u0061\u0075\u0074\u006f\u006d\u0061\u0074\u0069\u0063\u0061\u006c\u006c\u0079\u0020\u0066\u0069\u006c\u006c\u0065\u0064\u0020\u0077\u0069\u0074\u0068\u0020\u0074\u0068\u0065\u0020\u0073\u0061\u006d\u0065\u0020\u0068\u006f\u0073\u0074\u0020\u006e\u0061\u006d\u0065\u0020\u0061\u0073\u0020\u0079\u006f\u0075\u0072\u0020\u0077\u0065\u0062\u0073\u0069\u0074\u0065\u002e\u0026\u006e\u0062\u0073\u0070\u003b\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u003c\u0069\u006d\u0067\u0020\u0073\u0072\u0063\u003d\u0022\u002f\u0075\u0070\u006c\u006f\u0061\u0064\u0073\u002f\u0069\u006d\u0067\u002d\u0063\u0039\u0033\u0037\u0064\u0064\u0064\u0030\u002d\u0032\u0064\u0033\u0032\u002d\u0034\u0066\u0063\u0038\u002d\u0061\u0037\u0037\u0036\u002d\u0031\u0038\u0035\u0064\u0038\u0037\u0064\u0061\u0062\u0065\u0061\u0032\u002e\u0070\u006e\u0067\u0022\u0020\u0061\u006c\u0074\u003d\u0022\u0022\u0020\u006c\u006f\u0061\u0064\u0069\u006e\u0067\u003d\u0022\u006c\u0061\u007a\u0079\u0022\u0020\u0063\u006c\u0061\u0073\u0073\u003d\u0022\u0069\u006d\u0067\u002d\u0066\u006c\u0075\u0069\u0064\u0020\u0069\u006d\u0067\u002d\u0074\u0068\u0075\u006d\u0062\u006e\u0061\u0069\u006c\u0022\u003e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0049\u0074\u0027\u0073\u0020\u0064\u0065\u0073\u0063\u0072\u0069\u0070\u0074\u0069\u006f\u006e\u0020\u0069\u0073\u003a\u0020\u0022\u003c\u0065\u006d\u003e\u0054\u0068\u0065\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u0020\u0076\u0061\u006c\u0075\u0065\u0020\u0073\u0065\u006e\u0074\u0020\u0074\u006f\u0020\u0074\u0068\u0065\u0020\u0062\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0077\u0069\u0074\u0068\u0020\u0065\u0061\u0063\u0068\u0020\u0072\u0065\u0071\u0075\u0065\u0073\u0074\u002e\u0020\u0049\u0066\u0020\u0079\u006f\u0075\u0020\u006c\u0065\u0061\u0076\u0065\u0020\u0074\u0068\u0069\u0073\u0020\u0062\u006c\u0061\u006e\u006b\u002c\u0020\u0074\u0068\u0065\u0020\u0072\u0065\u0071\u0075\u0065\u0073\u0074\u0020\u0068\u006f\u0073\u0074\u006e\u0061\u006d\u0065\u0020\u0064\u0065\u0074\u0065\u0072\u006d\u0069\u006e\u0065\u0073\u0020\u0074\u0068\u0069\u0073\u0020\u0076\u0061\u006c\u0075\u0065\u002e\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0073\u0065\u0072\u0076\u0069\u0063\u0065\u0073\u002c\u0020\u0073\u0075\u0063\u0068\u0020\u0061\u0073\u0020\u0057\u0065\u0062\u0020\u0041\u0070\u0070\u0073\u002c\u0020\u0042\u006c\u006f\u0062\u0020\u0053\u0074\u006f\u0072\u0061\u0067\u0065\u002c\u0020\u0061\u006e\u0064\u0020\u0043\u006c\u006f\u0075\u0064\u0020\u0073\u0065\u0072\u0076\u0069\u0063\u0065\u0073\u002c\u0020\u0072\u0065\u0071\u0075\u0069\u0072\u0065\u0020\u0074\u0068\u0069\u0073\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u0020\u0076\u0061\u006c\u0075\u0065\u0020\u0074\u006f\u0020\u006d\u0061\u0074\u0063\u0068\u0020\u0074\u0068\u0065\u0020\u0074\u0061\u0072\u0067\u0065\u0074\u0020\u0068\u006f\u0073\u0074\u0020\u006e\u0061\u006d\u0065\u0020\u0062\u0079\u0020\u0064\u0065\u0066\u0061\u0075\u006c\u0074\u002e\u003c\u002f\u0065\u006d\u003e\u0022\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0053\u006f\u0020\u0077\u0065\u0020\u006a\u0075\u0073\u0074\u0020\u0068\u0061\u0076\u0065\u0020\u0074\u006f\u0020\u003c\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u006c\u0065\u0061\u0076\u0065\u0020\u0074\u0068\u0069\u0073\u0020\u0066\u0069\u0065\u006c\u0064\u0020\u0062\u006c\u0061\u006e\u006b\u003c\u002f\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u002e\u0020\u0057\u0065\u0020\u0063\u0061\u006e\u0020\u0064\u006f\u0020\u0074\u0068\u0069\u0073\u0020\u0062\u0079\u0020\u0065\u0064\u0069\u0074\u0069\u006e\u0067\u0020\u0061\u006e\u0020\u0065\u0078\u0069\u0073\u0074\u0069\u006e\u0067\u0020\u0062\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0070\u006f\u006f\u006c\u002e\u0026\u006e\u0062\u0073\u0070\u003b\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u004f\u0070\u0065\u006e\u0020\u0074\u0068\u0065\u0020\u0062\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0070\u006f\u006f\u006c\u0020\u0066\u006f\u0072\u0020\u0065\u0064\u0069\u0074\u002c\u0020\u0069\u006e\u0020\u006d\u0079\u0020\u0063\u0061\u0073\u0065\u002c\u0020\u0069\u0074\u0073\u0020\u0022\u0061\u0070\u0070\u0073\u0065\u0072\u0076\u0069\u0063\u0065\u002d\u0065\u0064\u0069\u002d\u0077\u0061\u006e\u0067\u0022\u002e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u003c\u0069\u006d\u0067\u0020\u0073\u0072\u0063\u003d\u0022\u002f\u0075\u0070\u006c\u006f\u0061\u0064\u0073\u002f\u0069\u006d\u0067\u002d\u0039\u0062\u0035\u0063\u0036\u0032\u0061\u0030\u002d\u0030\u0032\u0061\u0063\u002d\u0034\u0039\u0033\u0065\u002d\u0061\u0033\u0032\u0031\u002d\u0036\u0031\u0064\u0064\u0036\u0036\u0062\u0030\u0033\u0036\u0037\u0065\u002e\u0070\u006e\u0067\u0022\u0020\u0061\u006c\u0074\u003d\u0022\u0022\u0020\u006c\u006f\u0061\u0064\u0069\u006e\u0067\u003d\u0022\u006c\u0061\u007a\u0079\u0022\u0020\u0063\u006c\u0061\u0073\u0073\u003d\u0022\u0069\u006d\u0067\u002d\u0066\u006c\u0075\u0069\u0064\u0020\u0069\u006d\u0067\u002d\u0074\u0068\u0075\u006d\u0062\u006e\u0061\u0069\u006c\u0022\u003e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0043\u006c\u0069\u0063\u006b\u0020\u0074\u0068\u0065\u0020\u0065\u006e\u0074\u0072\u0079\u0020\u0069\u006e\u0020\u0022\u003c\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0042\u0041\u0043\u004b\u0045\u004e\u0044\u0053\u003c\u002f\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0022\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u003c\u0069\u006d\u0067\u0020\u0073\u0072\u0063\u003d\u0022\u002f\u0075\u0070\u006c\u006f\u0061\u0064\u0073\u002f\u0069\u006d\u0067\u002d\u0031\u0031\u0066\u0061\u0038\u0064\u0032\u0032\u002d\u0031\u0063\u0030\u0030\u002d\u0034\u0063\u0037\u0066\u002d\u0039\u0039\u0063\u0066\u002d\u0063\u0036\u0033\u0066\u0031\u0038\u0066\u0039\u0032\u0035\u0065\u0066\u002e\u0070\u006e\u0067\u0022\u0020\u0061\u006c\u0074\u003d\u0022\u0022\u0020\u006c\u006f\u0061\u0064\u0069\u006e\u0067\u003d\u0022\u006c\u0061\u007a\u0079\u0022\u0020\u0063\u006c\u0061\u0073\u0073\u003d\u0022\u0069\u006d\u0067\u002d\u0066\u006c\u0075\u0069\u0064\u0020\u0069\u006d\u0067\u002d\u0074\u0068\u0075\u006d\u0062\u006e\u0061\u0069\u006c\u0022\u003e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0041\u006e\u0064\u0020\u0064\u0065\u006c\u0065\u0074\u0065\u0020\u0074\u0068\u0065\u0020\u0063\u006f\u006e\u0074\u0065\u006e\u0074\u0020\u0069\u006e\u0020\u0022\u003c\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0042\u0061\u0063\u006b\u0065\u006e\u0064\u0020\u0068\u006f\u0073\u0074\u0020\u0068\u0065\u0061\u0064\u0065\u0072\u003c\u002f\u0073\u0074\u0072\u006f\u006e\u0067\u003e\u0022\u002c\u0020\u006c\u0065\u0061\u0076\u0065\u0020\u0069\u0074\u0020\u0062\u006c\u0061\u006e\u006b\u002e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u003c\u0069\u006d\u0067\u0020\u0073\u0072\u0063\u003d\u0022\u002f\u0075\u0070\u006c\u006f\u0061\u0064\u0073\u002f\u0069\u006d\u0067\u002d\u0038\u0035\u0064\u0065\u0033\u0031\u0032\u0064\u002d\u0039\u0063\u0033\u0037\u002d\u0034\u0062\u0030\u0063\u002d\u0062\u0033\u0066\u0066\u002d\u0035\u0034\u0034\u0038\u0031\u0036\u0033\u0065\u0032\u0064\u0031\u0031\u002e\u0070\u006e\u0067\u0022\u0020\u0061\u006c\u0074\u003d\u0022\u0022\u0020\u006c\u006f\u0061\u0064\u0069\u006e\u0067\u003d\u0022\u006c\u0061\u007a\u0079\u0022\u0020\u0063\u006c\u0061\u0073\u0073\u003d\u0022\u0069\u006d\u0067\u002d\u0066\u006c\u0075\u0069\u0064\u0020\u0069\u006d\u0067\u002d\u0074\u0068\u0075\u006d\u0062\u006e\u0061\u0069\u006c\u0022\u003e\u003c\u002f\u0070\u003e\u000a\u003c\u0070\u003e\u0053\u0061\u0076\u0065\u0020\u0074\u0068\u0065\u0020\u0063\u0068\u0061\u006e\u0067\u0065\u0073\u002c\u0020\u0061\u006e\u0064\u0020\u0074\u0068\u0065\u0020\u0041\u007a\u0075\u0072\u0065\u0020\u0041\u0044\u0020\u0073\u0069\u0067\u006e\u0020\u0069\u006e\u0020\u0077\u0069\u006c\u006c\u0020\u0077\u006f\u0072\u006b\u0020\u0061\u0067\u0061\u0069\u006e\u0020\u0069\u006e\u0020\u0061\u0020\u0066\u0065\u0077\u0020\u006d\u0069\u006e\u0075\u0074\u0065\u0073\u0021\u003c\u002f\u0070\u003e",
                    CommentEnabled = true,
                    CreateOnUtc = DateTime.UtcNow,
                    ContentAbstract = "Today I am migrating my blog to use Azure Front Door which I have introduced in a previous blog post last year. Everything went well except for the blog admin sign in. I configured my blog to Azure AD as SSO. But after I put the blog behind Azure Front Door with my custom domain, OIDC Redirect URL just blow up. OIDC Redirection Failure When I tried to sign in, the redirection URL suddenly …",
                    PostExtension = new PostExtensionEntity
                    {
                        PostId = newPostId1,
                        Hits = 5,
                        Likes = 3
                    }
                });
            }

            if (!context.PostPublish.Any())
            {
                context.Add(new PostPublishEntity
                {
                    PostId = newPostId0,
                    IsPublished = true,
                    ExposedToSiteMap = true,
                    IsFeedIncluded = true,
                    LastModifiedUtc = null,
                    IsDeleted = false,
                    PubDateUtc = DateTime.UtcNow,
                    Revision = 0,
                    PublisherIp = "127.0.0.1",
                    ContentLanguageCode = "en-us"
                });

                context.Add(new PostPublishEntity
                {
                    PostId = newPostId1,
                    IsPublished = true,
                    ExposedToSiteMap = true,
                    IsFeedIncluded = true,
                    LastModifiedUtc = null,
                    IsDeleted = false,
                    PubDateUtc = DateTime.UtcNow,
                    Revision = 0,
                    PublisherIp = "127.0.1.1",
                    ContentLanguageCode = "en-us"
                });
            }

            if (!context.PostCategory.Any())
            {
                context.Add(new PostCategoryEntity
                {
                    PostId = newPostId0,
                    CategoryId = newCategoryId0,
                });

                context.Add(new PostCategoryEntity
                {
                    PostId = newPostId1,
                    CategoryId = newCategoryId1,
                });

                context.Add(new PostCategoryEntity
                {
                    PostId = newPostId1,
                    CategoryId = newCategoryId2,
                });
            }

            if (!context.PostTag.Any())
            {
                context.Add(new PostTagEntity
                {
                    PostId = newPostId0,
                    TagId = 1
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId0,
                    TagId = 2
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId0,
                    TagId = 3
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId1,
                    TagId = 4
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId1,
                    TagId = 5
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId1,
                    TagId = 6
                });
            }

            if (!context.CustomPage.Any())
            {
                context.Add(new CustomPageEntity
                {
                    Id = Guid.Parse("b4103e89-058b-486a-8d44-7bd4433da48b"),
                    Title = "About",
                    Slug = "about",
                    MetaDescription = "An Empty About Page",
                    HtmlContent = "<h3>An Empty About Page</h3>",
                    CssContent = "",
                    HideSidebar = true,
                    CreateOnUtc = DateTime.UtcNow,
                    UpdatedOnUtc = DateTime.UtcNow
                });
            }

            if (!context.AdvancedSettings.Any())
            {
                context.Add(new AdvancedSettingsEntity
                {
                    Id = Guid.Parse("42df3de7-2fae-424d-8376-511de8a17824"),
                    DNSPrefetchEndpoint = ""
                });
            }

            if (!context.ContentSettings.Any())
            {
                context.Add(new ContentSettingsEntity
                {
                    Id = Guid.Parse("2d499084-b60a-44c3-8987-7ed8e124231b"),
                    DisharmonyWords = "fuck|shit",
                    EnableComments = true,
                    RequireCommentReview = true,
                    EnableWordFilter = false,
                    UseFriendlyNotFoundImage = true,
                    PostListPageSize = 10,
                    HotTagAmount = 10,
                    ShowCalloutSection = false
                });
            }

            if (!context.FeedSettings.Any())
            {
                context.Add(new FeedSettingsEntity
                {
                    Id = Guid.Parse("40265019-659f-4435-84ae-a2ff86e3691a"),
                    RssItemCount = 20,
                    RssCopyright = "(c) {year} BioWorld",
                    RssDescription = "Latest posts from BioWorld",
                    RssGeneratorName = "BioWorld",
                    RssTitle = "BioWorld",
                    AuthorName = "Admin",
                    UseFullContent = false
                });
            }

            if (!context.FriendLinksSettings.Any())
            {
                context.Add(new FriendLinksSettingsEntity
                {
                    Id = Guid.Parse("5789c7fc-f265-420e-bee8-7f6bb575a1df"),
                    ShowFriendLinksSection = true
                });
            }

            if (!context.GeneralSettings.Any())
            {
                context.Add(new GeneralSettingsEntity
                {
                    Id = Guid.Parse("0bd0b539-ecbb-4ce5-897c-b0d832457d12"),
                    OwnerName = "Admin",
                    Description = "BioWorld Admin",
                    ShortDescription = "BioWorld Admin",
                    AvatarBase64 = "",
                    SiteTitle = "BioWorld",
                    LogoText = "bioworld",
                    MetaKeyword = "bioworld",
                    MetaDescription = "Just another .NET blog system",
                    Copyright = "&copy; 2020",
                    SideBarCustomizedHtmlPitch = "",
                    FooterCustomizedHtmlPitch = "",
                    TimeZoneUtcOffset = "08:00:00",
                    TimeZoneId = "China Standard Time"
                });
            }

            if (!context.NotificationSettings.Any())
            {
                context.Add(new NotificationSettingsEntity
                {
                    Id = Guid.Parse("b6c23324-866d-4e40-a9ef-d205afbae45e"),
                    EnableEmailSending = true,
                    SendEmailOnCommentReply = true,
                    SendEmailOnNewComment = true,
                    AdminEmail = "yzl_200@sina.com",
                    EmailDisplayName = "BioWorld"
                });
            }

            if (!context.WatermarkSettings.Any())
            {
                context.Add(new WatermarkSettingsEntity
                {
                    Id = Guid.Parse("7f1a3967-47b3-4b74-9aeb-3c35952d1ed7"),
                    IsEnabled = true,
                    KeepOriginImage = false,
                    FontSize = 20,
                    WatermarkText = "BioWorld"
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
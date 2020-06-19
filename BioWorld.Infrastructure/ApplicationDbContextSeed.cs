using System;
using System.Linq;
using System.Threading.Tasks;
using BioWorld.Domain.Entities;
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
            Guid newCategoryId = Guid.Parse("9710daba-ae1b-462c-9252-8eacf90f45a8");

            // Seed, if necessary
            if (!context.Category.Any())
            {
                context.Category.Add(new CategoryEntity
                {
                    Id = newCategoryId,
                    DisplayName = "Default",
                    Note = "Default Category",
                    RouteName = "default"
                });
            }

            if (!context.Tag.Any())
            {
                context.Tag.Add(new TagEntity()
                {
                    //Id = 0,
                    DisplayName = ".NET Core",
                    NormalizedName = "dotnet-core"
                });

                context.Tag.Add(new TagEntity()
                {
                    //Id = 1,
                    DisplayName = "Azure",
                    NormalizedName = "azure"
                });
            }

            if (!context.FriendLink.Any())
            {
                context.Add(new FriendLinkEntity
                {
                    Id = Guid.Parse("f4079a57-3d22-4ab8-9fdf-25c31f4f5644"),
                    LinkUrl = "https://edi.wang",
                    Title = "Edi.Wang"
                });
            }

            if (!context.Menu.Any())
            {
                context.Add(new MenuEntity
                {
                    Id = Guid.Parse("06d83988-c254-43b9-9220-d3a4a862fae8"),
                    Title = "About",
                    Url = "",
                    Icon = "icon-star-full",
                    DisplayOrder = 0,
                    IsOpenInNewTab = false
                });
            }

            Guid newPostId = Guid.Parse("4886ec88-fc7b-4338-9fd2-56411187a7f7");

            if (!context.Post.Any())
            {
                context.Add(new PostEntity
                {
                    Id = newPostId,
                    Title = "Welcome to BioWorld",
                    Slug = "welcome-to-bioworld",
                    PostContent =
                        "Bioworld is the new blog system for https://edi.wang. It is a complete rewrite of the old system using .NET Core and runs on Microsoft Azure.",
                    CommentEnabled = true,
                    CreateOnUtc = DateTime.UtcNow,
                    ContentAbstract = "new blog system",
                    PostExtension = new PostExtensionEntity
                    {
                        PostId = newPostId,
                        Hits = 1024,
                        Likes = 512
                    }
                });
            }

            if (!context.PostPublish.Any())
            {
                context.Add(new PostPublishEntity
                {
                    PostId = newPostId,
                    IsPublished = true,
                    ExposedToSiteMap = true,
                    IsFeedIncluded = true,
                    LastModifiedUtc = DateTime.UtcNow,
                    IsDeleted = false,
                    PubDateUtc = DateTime.UtcNow,
                    Revision = 0,
                    PublisherIp = "127.0.0.1",
                    ContentLanguageCode = "en-us"
                });
            }

            if (!context.PostCategory.Any())
            {
                context.Add(new PostCategoryEntity
                {
                    PostId = newPostId,
                    CategoryId = newCategoryId,
                });
            }

            if (!context.PostTag.Any())
            {
                context.Add(new PostTagEntity
                {
                    PostId = newPostId,
                    TagId = 0
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId,
                    TagId = 1
                });
            }

            if (!context.CustomPage.Any())
            {
                context.Add(new CustomPageEntity
                {
                    Id = Guid.Parse("b4103e89-058b-486a-8d44-7bd4433da48b"), //Guid.NewGuid(),
                    Title = "About",
                    RouteName = "about",
                    HtmlContent = "'An Empty About Page",
                    CssContent = "N",
                    HideSidebar = true,
                    CreateOnUtc = DateTime.UtcNow,
                    UpdatedOnUtc = DateTime.UtcNow
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
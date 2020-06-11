using System;
using System.Threading.Tasks;
using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace BioWorld.Infrastructure
{
    public static class BlogDbContextSeed
    {
        public static async Task SeedSampleDataAsync(BlogDbContext context)
        {
            // Seed, if necessary
            if (!context.Category.Any())
            {
                context.Category.Add(new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "Default",
                    Note = "Default Category",
                    RouteName = "default"
                });
            }

            if (!context.Tag.Any())
            {
                context.Tag.Add(new TagEntity()
                {
                    Id = 0,
                    DisplayName = ".NET Core",
                    NormalizedName = "dotnet-core"
                });

                context.Tag.Add(new TagEntity()
                {
                    Id = 1,
                    DisplayName = "Azure",
                    NormalizedName = "azure"
                });
            }

            if (!context.FriendLink.Any())
            {
                context.Add(new FriendLinkEntity
                {
                    Id = Guid.NewGuid(),
                    LinkUrl = "https://edi.wang",
                    Title = "Edi.Wang"
                });
            }

            if (!context.Menu.Any())
            {
                context.Add(new MenuEntity
                {
                    Id = Guid.NewGuid(),
                    Title = "About",
                    Url = "",
                    Icon = "icon-star-full",
                    DisplayOrder = 0,
                    IsOpenInNewTab = false
                });
            }

            Guid newPostId = Guid.NewGuid();

            Guid neCategoryId =Guid.NewGuid();

            if (!context.Post.Any())
            {
                context.Add(new PostEntity
                {
                    Id = newPostId,
                    Title = "Welcome to BioWorld",
                    Slug = "welcome-to-bioworld",
                    PostContent = "Bioworld is the new blog system for https://edi.wang. It is a complete rewrite of the old system using .NET Core and runs on Microsoft Azure.",
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
                    CategoryId = neCategoryId,
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
                    Id = Guid.NewGuid(),
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
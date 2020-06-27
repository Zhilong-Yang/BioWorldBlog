using System;
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

            Guid newPostId = Guid.Parse("4886ec88-fc7b-4338-9fd2-56411187a7f7");

            if (!context.Post.Any())
            {
                context.Add(new PostEntity
                {
                    Id = newPostId,
                    Title = "Welcome to BioWorld",
                    Slug = "welcome-to-bioworld",
                    PostContent =
                        "Bioworld is the new blog system for https://zhilong.yang. It is a complete rewrite of the old system using .NET Core and runs on Microsoft Azure.",
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
                    LastModifiedUtc = null,
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
                    TagId = 1
                });

                context.Add(new PostTagEntity
                {
                    PostId = newPostId,
                    TagId = 2
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
                    DNSPrefetchEndpoint = ""
                });
            }

            if (!context.ContentSettings.Any())
            {
                context.Add(new ContentSettingsEntity
                {
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
                    ShowFriendLinksSection = true
                });
            }

            if (!context.GeneralSettings.Any())
            {
                context.Add(new GeneralSettingsEntity
                {
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
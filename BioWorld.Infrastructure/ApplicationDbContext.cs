using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Common;
using BioWorld.Domain.Entities;
using BioWorld.Domain.Entities.Cfg;
using BioWorld.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BioWorld.Infrastructure
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public virtual DbSet<CategoryEntity> Category { get; set; }
        public virtual DbSet<CommentEntity> Comment { get; set; }
        public virtual DbSet<CommentReplyEntity> CommentReply { get; set; }
        public virtual DbSet<PingbackHistoryEntity> PingbackHistory { get; set; }
        public virtual DbSet<PostEntity> Post { get; set; }
        public virtual DbSet<PostCategoryEntity> PostCategory { get; set; }
        public virtual DbSet<PostExtensionEntity> PostExtension { get; set; }
        public virtual DbSet<PostPublishEntity> PostPublish { get; set; }
        public virtual DbSet<PostTagEntity> PostTag { get; set; }
        public virtual DbSet<TagEntity> Tag { get; set; }
        public virtual DbSet<FriendLinkEntity> FriendLink { get; set; }
        public virtual DbSet<CustomPageEntity> CustomPage { get; set; }
        public virtual DbSet<MenuEntity> Menu { get; set; }

        public virtual DbSet<AdvancedSettingsEntity> AdvancedSettings { get; set; }
        public virtual DbSet<ContentSettingsEntity> ContentSettings { get; set; }
        public virtual DbSet<FeedSettingsEntity> FeedSettings { get; set; }
        public virtual DbSet<FriendLinksSettingsEntity> FriendLinksSettings { get; set; }
        public virtual DbSet<GeneralSettingsEntity> GeneralSettings { get; set; }
        public virtual DbSet<NotificationSettingsEntity> NotificationSettings { get; set; }
        public virtual DbSet<WatermarkSettingsEntity> WatermarkSettings { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.GetNowWithUserTZone();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.GetNowWithUserTZone();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
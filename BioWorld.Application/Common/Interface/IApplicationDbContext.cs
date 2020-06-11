using System.Threading;
using System.Threading.Tasks;
using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<CategoryEntity> Category { get; set; }
        DbSet<CommentEntity> Comment { get; set; }
        DbSet<CommentReplyEntity> CommentReply { get; set; }
        DbSet<PingbackHistoryEntity> PingbackHistory { get; set; }
        DbSet<PostEntity> Post { get; set; }
        DbSet<PostCategoryEntity> PostCategory { get; set; }
        DbSet<PostExtensionEntity> PostExtension { get; set; }
        DbSet<PostPublishEntity> PostPublish { get; set; }
        DbSet<PostTagEntity> PostTag { get; set; }
        DbSet<TagEntity> Tag { get; set; }
        DbSet<FriendLinkEntity> FriendLink { get; set; }
        DbSet<CustomPageEntity> CustomPage { get; set; }
        DbSet<MenuEntity> Menu { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
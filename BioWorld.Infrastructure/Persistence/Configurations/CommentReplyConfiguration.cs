﻿using BioWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioWorld.Infrastructure.Persistence.Configurations
{
    class CommentReplyConfiguration : IEntityTypeConfiguration<CommentReplyEntity>
    {
        public void Configure(EntityTypeBuilder<CommentReplyEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.IpAddress).HasMaxLength(64);
            builder.Property(e => e.ReplyTimeUtc).HasColumnType("datetime");
            builder.Property(e => e.UserAgent).HasMaxLength(512);
            builder.HasOne(d => d.Comment)
                .WithMany(p => p.CommentReply)
                .HasForeignKey(d => d.CommentId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Data.Configuration
{
    internal class ChatHistoryConfiguration : IEntityTypeConfiguration<ChatHistoryEntry>
    {
        public void Configure(EntityTypeBuilder<ChatHistoryEntry> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Question).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Answer).HasMaxLength(1000);
            builder.Property(p => p.CreatedAt).IsRequired();
        }

    }
}

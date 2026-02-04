using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Data;

public class PetWorldDbContext : DbContext
{
    public PetWorldDbContext(DbContextOptions<PetWorldDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ChatHistoryEntry> ChatHistory { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChatHistoryEntry>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Question)
                   .IsRequired()
                   .HasColumnType("TEXT");  // Avoid truncation
            builder.Property(e => e.Answer)
                   .IsRequired()
                   .HasColumnType("TEXT");  // Avoid truncation
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("DATETIME");
        });
    }
}

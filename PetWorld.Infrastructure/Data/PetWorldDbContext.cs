using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Data
{
    /// <summary>
    /// Główny kontekst bazy danych dla aplikacji PetWorld.
    /// Zarządza tabelami Products i ChatHistory.
    /// </summary>
    public class PetWorldDbContext : DbContext
    {
        /// <summary>
        /// Konstruktor przyjmujący konfigurację bazy danych.
        /// </summary>
        /// <param name="options">Opcje konfiguracji DbContext</param>
        public PetWorldDbContext(DbContextOptions<PetWorldDbContext> options)
            : base(options) { }

        /// <summary>
        /// Tabela produktów w bazie danych
        /// </summary>
        public DbSet<Product> Products { get; set; } = null!;

        /// <summary>
        /// Tabela historii czatu w bazie danych
        /// </summary>
        public DbSet<ChatHistoryEntry> ChatHistory { get; set; } = null!;

        /// <summary>
        /// Konfiguracja mapowania encji na tabele i kolumny bazy danych
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder do konfiguracji encji</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja encji Product
            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnType("TEXT");
                builder.Property(p => p.Description)
                    .IsRequired()
                    .HasColumnType("TEXT");
                builder.Property(p => p.Category)
                    .IsRequired()
                    .HasColumnType("TEXT");
                builder.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("DECIMAL(18,2)");
            });

            // Konfiguracja encji ChatHistoryEntry
            modelBuilder.Entity<ChatHistoryEntry>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Question)
                       .IsRequired()
                       .HasColumnType("TEXT");
                builder.Property(e => e.Answer)
                       .IsRequired()
                       .HasColumnType("TEXT");
                builder.Property(e => e.CreatedAt)
                       .IsRequired()
                       .HasColumnType("DATETIME");
            });
        }
    }
}
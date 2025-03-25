using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyTimeProject.Core.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyTimeProject.Data
{
    public class DataContext:DbContext
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Presence> Presences { get; set; }
        public DbSet<Approvals> Approvals { get; set; }
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasKey(u => u.Id); // הגדרת מפתח ראשי עבור User

            modelBuilder.Entity<Presence>()
                .HasKey(p => p.Id); // הגדרת מפתח ראשי עבור Presence

            modelBuilder.Entity<Presence>()
                .HasOne<User>() // קשר ל-User
                .WithMany(u => u.ListPresences) // קשר לקולקציה ב-User
                .HasForeignKey(p => p.UserId) // הגדרת UserId כמפתח זר
                .OnDelete(DeleteBehavior.Cascade); // התנהגות מחיקה

            modelBuilder.Entity<Presence>()
                .Property(e => e.Date)
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue), // המרה ל-DateTime
                    v => DateOnly.FromDateTime(v)); // המרה מ-DateTime

            modelBuilder.Entity<Presence>()
                .Property(e => e.TimeOfStart )
                .HasConversion(
                    v => v.ToTimeSpan(), // המרה ל-TimeSpan
                    v => TimeOnly.FromTimeSpan(v)); // המרה מ-TimeSpan

            modelBuilder.Entity<Presence>()
               .Property(e => e.TimeOfEnd)
               .HasConversion(
                   v => v.ToTimeSpan(), // המרה ל-TimeSpan
                   v => TimeOnly.FromTimeSpan(v)); // המרה מ-TimeSpan

            modelBuilder.Entity<Approvals>()
        .HasKey(a => a.Id); // הגדרת המפתח הראשי

            modelBuilder.Entity<Approvals>()
                .Property(a => a.ContentType)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            }
            catch (Exception ex)
            {
                logger.Error($"Error configuring database: {ex.Message}");
            }
        }
    }
 
}

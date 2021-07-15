using EmailRules.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailRules.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailRule>()
            .HasMany(c => c.Conditions)
            .WithOne(e => e.Rule!)
            .HasForeignKey(c => c.RuleId);

            modelBuilder.Entity<EmailRule>()
            .HasMany(c => c.Actions)
            .WithOne(e => e.Rule!)
            .HasForeignKey(c => c.RuleId);

            modelBuilder
            .Entity<EmailCondition>()
            .HasOne(r => r.Rule)
            .WithMany(p => p.Conditions)
            .HasForeignKey(p => p.RuleId);

            modelBuilder
            .Entity<EmailAction>()
            .HasOne(r => r.Rule)
            .WithMany(p => p.Actions)
            .HasForeignKey(p => p.RuleId);
        }

        public DbSet<EmailRule> Rules { get; set; }
        public DbSet<EmailAction> Actions { get; set; }
        public DbSet<EmailCondition> Conditions { get; set; }
    }
}
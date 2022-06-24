namespace WebAppSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebAppSystem.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
                .HasOne(t => t.Sender)
                .WithMany(t => t.SentTransactions)
                .HasForeignKey(t => t.SenderId);

            builder.Entity<Transaction>()
                .HasOne(t => t.Recipient)
                .WithMany(t => t.ReceivedTransactions)
                .HasForeignKey(t => t.RecipientId);
        }
    }
}
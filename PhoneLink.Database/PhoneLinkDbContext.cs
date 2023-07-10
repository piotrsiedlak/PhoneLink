using Microsoft.EntityFrameworkCore;
using PhoneLink.Database.Models;

namespace PhoneLink.Database
{
    public class PhoneLinkDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<ContactGroups> ContactGroups { get; set; }

        public PhoneLinkDbContext(DbContextOptions options) : base(options)
        {
        }
        public PhoneLinkDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(u => u.UserContacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Contacts>()
                .HasOne(c => c.User)
                .WithMany(u => u.UserContacts)
                .HasForeignKey(c => c.UserId);

           /* modelBuilder.Entity<Contacts>()
                .HasMany(c => c.Favorites)
                .WithOne(f => f.Contact)
                .HasForeignKey(f => f.ContactId); */

            modelBuilder.Entity<ContactGroups>()
                .HasKey(cg => new { cg.GroupId, cg.ContactId });

            modelBuilder.Entity<ContactGroups>()
                .HasOne(cg => cg.Group)
                .WithMany(g => g.ContactGroups)
                .HasForeignKey(cg => cg.GroupId);

            /*modelBuilder.Entity<ContactGroups>()
                .HasOne(cg => cg.Contact)
                .WithMany(c => c.ContactGroups)
                .HasForeignKey(cg => cg.ContactId);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PhoneLink.db");
        }
    }
}

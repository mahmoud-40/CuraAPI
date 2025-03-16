using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cura.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medication>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalHistory>()
                .HasOne(mh => mh.User)
                .WithMany()
                .HasForeignKey(mh => mh.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
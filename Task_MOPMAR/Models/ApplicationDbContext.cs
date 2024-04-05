namespace Task_MOPMAR.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Village> Villages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Governorate)
                .WithMany()
                .HasForeignKey(e => e.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Center)
                .WithMany()
                .HasForeignKey(e => e.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Village)
                .WithMany()
                .HasForeignKey(e => e.VillageId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Center>()
            .HasOne(c => c.Governorate)
            .WithMany(g => g.Centers)
            .HasForeignKey(c => c.GovernorateId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Village>()
                .HasOne(v => v.Governorate)
                .WithMany()
                .HasForeignKey(v => v.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Village>()
                .HasOne(v => v.Center)
                .WithMany(c => c.Villages)
                .HasForeignKey(v => v.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        }
    }
}

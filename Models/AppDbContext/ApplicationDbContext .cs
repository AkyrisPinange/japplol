using Microsoft.EntityFrameworkCore;

namespace JAppInfos.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SummonerData> SummonerData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SummonerData>()
                .HasOne(sd => sd.User)
                .WithOne(u => u.SummonerData)
                .HasForeignKey<SummonerData>(sd => sd.UserId);
        }

    }

}

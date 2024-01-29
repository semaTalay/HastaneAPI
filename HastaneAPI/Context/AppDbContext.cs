using HastaneAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HastaneAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hastane> Hastane { get; set; }
        public DbSet<Hasta> Hasta { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hastane>().HasData(
                new Hastane()
                {
                    Id=1,
                    HastaneAd = "Kartal",
                    Adres = "İstanbul"
                    
                },
                  new Hastane()
                  {
                      Id = 2,
                      HastaneAd = "Pendik",
                      Adres = "İstanbul"
                  }
                );
            modelBuilder.Entity<Hasta>().HasData(
                new Hasta()
                {
                    Id = 1,
                    Ad = "Semanur",
                    Soyad = "Talay",
                    Klinik="KBB",
                    MuayeneTarihi=DateTime.Now,
                    HastaneId=1
                },
                  new Hasta()
                  {
                      Id = 2,
                      Ad = "AAA",
                      Soyad = "BBB",
                      Klinik="Göz",
                      MuayeneTarihi=DateTime.Now,
                      HastaneId=2
                  }
                );




        }
    }
}

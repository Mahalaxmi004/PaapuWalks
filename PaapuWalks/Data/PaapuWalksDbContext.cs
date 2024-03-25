using Microsoft.EntityFrameworkCore;
using PaapuWalks.Models.Domain;

namespace PaapuWalks.Data
{
    public class PaapuWalksDbContext :DbContext
    {
        public PaapuWalksDbContext(DbContextOptions<PaapuWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty>Difficulties { get; set; }
        public DbSet<Region>Regions { get; set; }
        public DbSet<Walk>Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id= Guid.Parse("6a55170e-ac65-48f4-9c1f-48af7dd6411b"),
                    Name = "Easy"
                },

            new Difficulty
            {
                Id = Guid.Parse("816b9f81-2dd7-4347-8b28-6935b7932da7"),
                Name = "Medium"
            },

                new Difficulty
                {
                    Id = Guid.Parse("8300acfc-fd4d-4d4c-80c2-9daf6ceae8f9"),
                    Name = "Hard"
                }
            };

            // seed difficulties to the data

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for regions
            var region = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("BDCF18B1-8958-43DE-8EF4-0274004930C3"),
                    Name = "Chennai",
                    Code= "CHN"

                },
                new Region
                {
                    Id = Guid.Parse("A0914C07-D365-4D95-20D6-08DC2D53CE90"),
                    Name = "Hyderabad",
                    Code= "HYD"
                },
                new Region
                {
                    Id = Guid.Parse("43232EE6-8F59-451A-20D7-08DC2D53CE90") ,
                    Name = "Kerala",
                    Code= "KLR"
                },
                new Region
                {
                    Id = Guid.Parse("139333E8-CD54-4F89-D92E-08DC2D5648A8"),
                    Name = "Banglore",
                    Code= "BLR"
                }
            };

            modelBuilder.Entity<Region>().HasData(region);
        }
    }
}

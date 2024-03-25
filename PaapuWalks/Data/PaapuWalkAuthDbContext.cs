using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PaapuWalks.Data
{
    public class PaapuWalkAuthDbContext : IdentityDbContext
    {
        public PaapuWalkAuthDbContext(DbContextOptions<PaapuWalkAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ReaderRoleId = "f5ce15a1-b04d-40b8-85a0-63d57cc0a6fa";
            var WriterRoleId = "d132e341-5ddd-41dd-a16f-c6540a719150";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    ConcurrencyStamp = ReaderRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id= WriterRoleId,
                    ConcurrencyStamp= WriterRoleId,
                    Name= "Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

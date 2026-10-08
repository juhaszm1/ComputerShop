using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ComputerShop.Models
{
    public class ComputerShopDBContext : DbContext
    {
        public ComputerShopDBContext(DbContextOptions options) : base(options)
        {
        }

        public ComputerShopDBContext()
        {
        }

        public DbSet<Osystem> Osystems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "server=localhost;database=computer;user=root;password=";

            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }
}

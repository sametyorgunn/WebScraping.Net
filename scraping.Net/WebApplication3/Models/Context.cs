using EntityLayer;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
namespace WebApplication3.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHVPQGR;Initial Catalog=corescraping;Integrated Security=True;Pooling=False");
        }

        public DbSet<About> abouts { get; set; }

        public DbSet<Comments> comments { get; set; }
    }
}

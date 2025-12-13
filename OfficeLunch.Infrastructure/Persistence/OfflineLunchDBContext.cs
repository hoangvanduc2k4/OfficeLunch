using Microsoft.EntityFrameworkCore;

namespace OfficeLunch.Infrastructure.Persistence
{
    public class OfflineLunchDBContext : DbContext
    {
        public OfflineLunchDBContext(DbContextOptions<OfflineLunchDBContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}

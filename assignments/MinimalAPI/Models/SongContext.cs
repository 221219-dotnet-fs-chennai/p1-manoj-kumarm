using Microsoft.EntityFrameworkCore;


namespace Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions options) : base(options) { }
        public DbSet<Songs> Songs { get; set; }
    }
}

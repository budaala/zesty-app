using Microsoft.EntityFrameworkCore;
using zesty_api.Models;

namespace zesty_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Products { get; set; }
        public DbSet<Rating> Ingredients { get; set; }
        public DbSet<Comment> Ratings { get; set; }
    }
}

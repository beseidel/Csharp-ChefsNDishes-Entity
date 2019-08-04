using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // "users" table is represented by this DbSet "Users"
        public DbSet<Chef> ChefsTable { get; set; }
        public DbSet<Dish> DishesTable { get; set; }
    }
}

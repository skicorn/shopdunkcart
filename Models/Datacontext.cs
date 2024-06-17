using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Cart.Models{
    public class Datacontext: DbContext{
        public Datacontext(DbContextOptions options): base(options) { }
        //declare fake data
        public DbSet<Product> Products => Set<Product>();
    }
}
using Microsoft.EntityFrameworkCore;

namespace WebApiNet.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<Merchandise> Products { get; set; }
        public DbSet<Category> categories { get; set; }
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //dotnet ef migrations add CreateInitial
        //dotnet ef database update
        //Productos
        public DbSet<Productos> Productos { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CinemaRepository.Context
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();

            // A mesma string de ligação que utilizou com sucesso nos testes
            var conStr = "Host=localhost;Port=5432;Database=CinemaDB;Username=postgres;Password=ifsp";
            optionsBuilder.UseNpgsql(conStr);

            return new MyDBContext(optionsBuilder.Options);
        }
    }
}
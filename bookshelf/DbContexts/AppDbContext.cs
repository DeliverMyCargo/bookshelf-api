using bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace bookshelf.DbContexts

{
    public class AppDbContext : DbContext
    {
        // Конструктор для DI (используется в рантайме)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Пустой конструктор для миграций (указываем провайдер явно)
        public AppDbContext() : base(GetOptions())
        {
        }

        // Метод, который возвращает готовые настройки для PostgreSQL
        private static DbContextOptions<AppDbContext> GetOptions()
        {
            // Используем ту же строку подключения, что и в appsettings.json
            var connectionString = "Host=localhost;Port=5433;Database=bookshelf;Username=postgres;Password=root";
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }

        public DbSet<Book> Books { get; set; }
    }
}
    


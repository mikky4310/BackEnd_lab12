using Microsoft.EntityFrameworkCore;

namespace lab12.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Table> Character { get; set; } //создаем таблицу с названием Character
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //создаем новую базу данных lab12 и подключаемся к ней
            optionsBuilder.UseSqlServer("Data Source=NASTYA;Initial Catalog=lab12;User ID=sa;Password=123; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}

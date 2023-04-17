using Microsoft.EntityFrameworkCore;
using api_counter.Models;

namespace api_counter
{
    public class ApiDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CounterDb");
        }
        public DbSet<Counter> Counters { get; set; }
    }
}

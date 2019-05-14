using Microsoft.EntityFrameworkCore;
using Reflections.Core.Models;

namespace Reflections.Data
{
    public class ReflectionsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ReflectionsContext()
        {
        }

        public ReflectionsContext(DbContextOptions<ReflectionsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID = postgres;Server=localhost;Database=Reflections;Integrated Security=true;Pooling=true");
            }
        }
    }
}

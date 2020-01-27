using Microsoft.EntityFrameworkCore;

namespace mysqltest
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=mysql_test;User=root;Password=my-secret-pw;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entry =>
            {
                entry.Property(x=>x.Name).HasMaxLength(200).IsRequired();
                entry.HasIndex(x => x.Name).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
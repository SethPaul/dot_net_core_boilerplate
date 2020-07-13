using Forecast;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ForecastCore.Services
{
    public class pgContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=forecasts;Username=dev;" +
            "Password=dev_pw",
            options => options.EnableRetryOnFailure());
// public pgContext(DbContextOptions<pgContext> options):base(options) {  }
        static pgContext()
            => NpgsqlConnection.GlobalTypeMapper.MapEnum<Summary>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.Entity<User>()
                // .HasIndex(b => b.Id)
                // .IncludeProperties(b => b.Name)
                // .HasMethod("gin")
                .Property(b => b.Id)
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.HasPostgresEnum<Summary>();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // from the group model (Entity framework will connect the Primarykey and forign key)
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}

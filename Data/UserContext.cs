
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Users.API.Model;

namespace Users.API.Data
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
    

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      var modelUser = modelBuilder.Entity<User>();
      modelUser.ToTable("tb_users");
      modelUser.HasKey(x => x.Id);
      modelUser.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
      modelUser.Property(x => x.Name).HasColumnName("name").IsRequired();
      modelUser.Property(x => x.Email).HasColumnName("email").IsRequired();
      modelUser.Property(x => x.Password).HasColumnName("password").IsRequired();
      modelUser.Property(x => x.Role).HasColumnName("role").IsRequired();
    }
 
    protected void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "Users");
    }
  }
}
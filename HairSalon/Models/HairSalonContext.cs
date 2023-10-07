using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class HairSalonContext : DbContext
  {
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Client> Clients {get; set;}
    
    public HairSalonContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasOne(c => c.Stylist)
            .WithMany(s => s.Clients)
            .HasForeignKey(c => c.StylistId);
    }
  }
}
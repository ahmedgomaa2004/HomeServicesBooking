using HomeServicesBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Service> Services => Set<Service>();

    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(service => service.Name).HasMaxLength(150).IsRequired();
            entity.Property(service => service.Description).IsRequired();
            entity.Property(service => service.IsActive).HasDefaultValue(true);
            entity.Property(service => service.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.HasIndex(service => service.IsActive);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(order => order.CustomerName).HasMaxLength(150).IsRequired();
            entity.Property(order => order.Phone).HasMaxLength(20).IsRequired();
            entity.Property(order => order.Address).HasMaxLength(300).IsRequired();
            entity.Property(order => order.ServiceName).HasMaxLength(150).IsRequired();
            entity.Property(order => order.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .HasDefaultValue(OrderStatus.Pending);
            entity.Property(order => order.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(order => order.Service)
                .WithMany(service => service.Orders)
                .HasForeignKey(order => order.ServiceId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(order => order.Status);
            entity.HasIndex(order => order.Phone);
            entity.HasIndex(order => order.CustomerName);
            entity.HasIndex(order => order.OrderDate);
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.Property(admin => admin.Email).HasMaxLength(150).IsRequired();
            entity.Property(admin => admin.PasswordHash).IsRequired();
            entity.Property(admin => admin.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.HasIndex(admin => admin.Email).IsUnique();
        });
    }
}

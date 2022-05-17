using EFCoreWorks.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWorks;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=127.0.0.1,12345;Database=efcorebug;User Id=MyUser;Password=MyPass;MultipleActiveResultSets=true;Connect Timeout=10;Max Pool Size=100;Pooling=True;");
    public DbSet<TenantEntity> Tenants { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<TenantUserAssociationEntity> TenantUserAssociations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.ApplyConfiguration(new TenantEntityConfig());
        b.ApplyConfiguration(new UserEntityConfig());
        b.ApplyConfiguration(new TenantUserAssociationEntityConfig());
    }
}
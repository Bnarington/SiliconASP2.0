using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<FeatureEntity> Features { get; set; }

    public DbSet<FeatureItemEntity> FeatureItems { get; set; }

    public DbSet<ShowcaseEntity> Showcases { get; set; }
    public DbSet<BrandItemEntity> BrandItems { get; set; }
}

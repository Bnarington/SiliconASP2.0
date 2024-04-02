using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class BrandItemRepo(DataContext context) : BaseRepo<FeatureItemEntity>(context)
{
    private readonly DataContext _context = context;
}
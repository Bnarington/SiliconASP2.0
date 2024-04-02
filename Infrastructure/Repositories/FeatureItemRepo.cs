using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class FeatureItemRepo(DataContext context) : BaseRepo<FeatureItemEntity>(context)
{
    private readonly DataContext _context = context;
}

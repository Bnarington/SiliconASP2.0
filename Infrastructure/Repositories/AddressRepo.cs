using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepo(DataContext context) : BaseRepo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

public class AccountRepo(DataContext context) : BaseRepo<UserEntity>(context)
{
    private readonly DataContext _context = context;
}

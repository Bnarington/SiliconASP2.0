using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShowcaseRepo(DataContext context) : BaseRepo<ShowcaseRepo>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<ShowcaseEntity> result = await _context.Showcases
                .Include(i => i.BrandItem)
                .ToListAsync();


            return ResponseFactory.OK(result);

        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}

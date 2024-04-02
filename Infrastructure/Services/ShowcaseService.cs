using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ShowcaseService(ShowcaseRepo showcaseRepo, BrandItemRepo brandItemRepo)
{
    private readonly ShowcaseRepo _showcaseRepo = showcaseRepo;
    private readonly BrandItemRepo _brandItemRepo = brandItemRepo;

    public async Task<ResponseResult> GetAllShowcasesAsync()
    {
        try
        {
            var result = await _showcaseRepo.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

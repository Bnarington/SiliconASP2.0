using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class FeatureService(FeautreRepo featureRepo, FeatureItemRepo featureItemRepo)
    {
        private readonly FeautreRepo _featureRepo = featureRepo;
        private readonly FeatureItemRepo _featureItemRepo = featureItemRepo;


        public async Task<ResponseResult> GetAllFeaturesAsync()
        {
            try
            {
                var result = await _featureRepo.GetAllAsync();
                return result;
            }
            catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
        }
    }
}

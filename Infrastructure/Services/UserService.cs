using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Services;

public class UserService(UserRepo repository, AddressService addressService)
{
    private readonly UserRepo _repository = repository;
    private readonly AddressService _addressService = addressService;

    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var exists = await _repository.EntityAllreadyExistsAsync(x => x.Email == model.Email);
            if (exists.StatusCode == StatusCode.EXISTS)
                return exists;

            var result = await _repository.CreateOneAsync(UserFactory.Create(model));
            if (result.StatusCode != StatusCode.OK)
                return result;



            return ResponseFactory.OK("User Created Successfully.");
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message);  }
    }
}

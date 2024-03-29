using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;
public class AddressService(AddressRepo repostiroy)
{
    private readonly AddressRepo _repostiroy = repostiroy;

    public async Task<ResponseResult> GetorCreateAddressAync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await GetAddressAync(streetName, postalCode, city);
            if (result.StatusCode == StatusCode.NOT_FOUND) 
                result = await CreateAddressAync(streetName, postalCode, city);

            return result;

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }


    public async Task<ResponseResult> CreateAddressAync(string streetName, string postalCode, string city)
    {
        try
        {
            var exists = await _repostiroy.EntityAllreadyExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (exists == null)
            {
                var result = await _repostiroy.CreateOneAsync(AddressFactory.Create(streetName, postalCode, city));
                if (result.StatusCode == StatusCode.OK)
                    return ResponseFactory.OK(AddressFactory.Create((AddressEntity)result.ContentResult!));

                return result;
            }
            return exists;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }


    }

    public async Task<ResponseResult> GetAddressAync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await _repostiroy.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }


    }

}


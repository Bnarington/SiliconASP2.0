﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;
public class AddressService(AddressRepo repository)
{
    private readonly AddressRepo _repository = repository;

    public async Task<ResponseResult> GetOrCreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await GetAddressAsync(streetName, postalCode, city);
            if (result.MyStatusCode == MyStatusCode.NOT_FOUND)
            {
                result = await CreateAddressAsync(streetName, postalCode, city);
            }
            return result;
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var existingAddress = await _repository.EntityAlreadyExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (existingAddress.MyStatusCode == MyStatusCode.NOT_FOUND)
            {
                var newAddress = AddressFactory.Create(streetName, postalCode, city);
                var result = await _repository.CreateOneAsync(newAddress);
                return result.MyStatusCode == MyStatusCode.OK ? ResponseFactory.OK(newAddress) : result;
            }
            return ResponseFactory.OK(existingAddress);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponseResult> GetAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            return await _repository.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}

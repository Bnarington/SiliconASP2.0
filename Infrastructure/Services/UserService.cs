﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
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

    public async Task<ResponseResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.Email == model.Email);
            if (result.StatusCode == StatusCode.OK && result.ContentResult != null)
            {
                var userEntity = (UserEntity)result.ContentResult;

                if (PwHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
                    return ResponseFactory.OK(userEntity);
            }

            return ResponseFactory.Error("Incorrect email or password.");
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}


public class SignInResult
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public UserEntity? UserEntity { get; set; }

    public static SignInResult Success(UserEntity userEntity)
    {
        return new SignInResult { IsSuccess = true, UserEntity = userEntity };
    }

    public static SignInResult Error(string message)
    {
        return new SignInResult { IsSuccess = false, ErrorMessage = message };
    }
}
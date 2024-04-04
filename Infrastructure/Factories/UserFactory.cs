﻿using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

internal class UserFactory
{
    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            var (password, securityKey) = PwHasher.GenerateSecurePw(model.Password);


            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = password,
                SecurityKey = securityKey, 
                Created = date,
                Modified = date
            };
        }
        catch { }
        return null!;
    }
}

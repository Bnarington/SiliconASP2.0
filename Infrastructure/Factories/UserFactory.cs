using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var userEntity = new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return userEntity;
        }
        catch { }
        return null!;
    }
}

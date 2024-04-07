using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

internal class AddressFactory
{
    public static AddressEntity Create(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = new AddressEntity
            {
                StreetName = streetName,
                PostalCode = postalCode,
                City = city
            };
            return addressEntity;
        }
        catch { }
        return null!;
    }
}

using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

internal class AddressFactory
{
    public static AddressEntity Create(string streetName, string optionalStreet, string postalCode, string city)
    {
        try
        {
            var addressEntity = new AddressEntity
            {
                StreetName = streetName,
                OptionalStreet = optionalStreet,
                PostalCode = postalCode,
                City = city
            };
            return addressEntity;
        }
        catch { }
        return null!;
    }
}

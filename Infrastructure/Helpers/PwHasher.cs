using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

internal class PwHasher
{
    public static (string, string) GenerateSecurePw(string password)
    {
        try
        {
            using var hmac = new HMACSHA512();
            var securityKey = hmac.Key;
            Console.WriteLine($"Computed Hash length: {securityKey.Length} bytes");
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            Console.WriteLine($"Computed Hash length: {computedHash.Length} bytes");
            return (Convert.ToBase64String(securityKey), Convert.ToBase64String(computedHash));
        }
        catch { }
        return (null!, null!);
    }


    public static bool ValidateSecurePassword(string password, string securityKey, string hashedPw)
    {
        try
        {
            using var hmac = new HMACSHA512(Convert.FromBase64String(securityKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = Convert.FromBase64String(hashedPw);

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hash[i])
                    return false;
            }

            return true;
        }
        catch { }
        return false;
    }

}

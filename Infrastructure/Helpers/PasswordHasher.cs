using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

internal class PasswordHasher
{
    public static (string, string) GenerateSecurePw(string password)
    {
        using var hmac = new HMACSHA512();
        var securityKey = hmac.Key;
        var hashedPw = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return (Convert.ToBase64String(securityKey), Convert.ToBase64String(hashedPw));

    }


    public static bool ValidateSecurePassword(string password, string hash, string securityKey)
    {

        var security = Convert.FromBase64String(securityKey);
        var pw = Convert.FromBase64String(hash);

        using var hmac = new HMACSHA512(security);
        var hashedPw = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

        for (var i=0; i<hashedPw.Length; i++)
        {
            if (hashedPw[i] != hash[i])
                return false;
        }

        return true;
    }
}

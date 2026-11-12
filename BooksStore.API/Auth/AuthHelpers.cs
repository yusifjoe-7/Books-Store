using System.Security.Cryptography;
using static System.Security.Cryptography.RandomNumberGenerator;
using System.Security.Cryptography;
using System.Text;
namespace BooksStore.Auth;

public class AuthHelpers
{
    

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];

        using var generator = RandomNumberGenerator.Create();

        generator.GetBytes(randomBytes);

        return Convert.ToBase64String(randomBytes);
    }
    

    public string Hash(string token)
    {
        var bytes = SHA256.HashData(
            Encoding.UTF8.GetBytes(token)
        );

        return Convert.ToBase64String(bytes);
    }
}

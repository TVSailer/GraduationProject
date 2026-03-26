using Domain.Service.AuthService.BaseAuthService;

namespace Domain.Service.AuthService;

public class AuthService : IAuthService
{
    private readonly Random _random = new ();

    public string GenerateAuthLogin(string text) => text + _random.Next(10000) ?? throw new ArgumentNullException();
    public string GenerateAuthPassword(string[]? hash, out string password)
    {
        while (true)
        {
            var pass = Generation(12);
            if (hash?.Length > 0 && hash.Any(h => BCrypt.Net.BCrypt.Verify(pass, h))) continue;
            password = pass;
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }

    private string Generation(int length)
    {
        // ReSharper disable once ComplexConditionExpression
        return string.Join("",
            Enumerable
                .Range(0, length)
                .Select(i => i % 2 == 0 ? 
                    (char)('A' + _random.Next(26)) + "" : 
                    _random.Next(1, 10) + "")
        );
    }
}
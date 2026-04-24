namespace Domain.ValidObject;

public class PasswordValidObject
{
    public string Password { get; }
    public string Hash => BCrypt.Net.BCrypt.HashPassword(Password);

    public PasswordValidObject(string[]? hash)
    {
        while (true)
        {
            var password = Generation(12);
            if (hash?.Length > 0 && hash.Any(h => BCrypt.Net.BCrypt.Verify(password, h))) continue;
            Password = password;
            return;
        }
    }

    public static string Generation(int length)
    {
        var random = new Random();
        // ReSharper disable once ComplexConditionExpression
        return string.Join("",
            Enumerable
                .Range(0, length)
                .Select(i => i % 2 == 0 ?
                    (char)('A' + random.Next(26)) + "" :
                    random.Next(1, 10) + "")
        );
    }
}
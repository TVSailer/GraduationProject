using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Microsoft.Extensions.Logging;

namespace DataAccess.Postgres.Models;

public class AuthEntity : Entity
{
    public string Login { get; set; }
    public string Password { get; set; }

    #region CreateAuth

    private readonly Random _random = new();
    private readonly AuthRepository _repository = new (new ApplicationDbContext());

    public AuthEntity CreateAuthUser(FIO fio, out string pas, out string log)
    {
        if (fio is null) throw new ArgumentNullException();
        var passwords = _repository.Get().Select(a => a.Password).ToArray();

        log = Login = fio?.Surname + _random.Next(10000);

        while (true)
        {
            var password = GenerationPassword(12);
            if (passwords.Any(p => BCrypt.Net.BCrypt.Verify(password, p))) continue;
            pas = password;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            _repository.Add(this);
            return this;
        }
    }

    private string GenerationPassword(int length)
    {
        // ReSharper disable once ComplexConditionExpression
        var password = string.Join("", // создаем строку
            Enumerable.Range(0, length) // из последовательности длины length
                .Select(i => i % 2 == 0
                    ? // на четных местах
                    (char)('A' + _random.Next(26)) + ""
                    : // генерируем букву
                    _random.Next(1, 10) + "") // на нечетных цифру
        );
        return password;
    }

    #endregion

}
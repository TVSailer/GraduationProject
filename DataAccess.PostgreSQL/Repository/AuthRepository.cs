using DataAccess.PostgreSQL.Logger;
using DataAccess.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using ILogger = DataAccess.PostgreSQL.Logger.ILogger;

namespace DataAccess.PostgreSQL.Repository;

public class AuthRepository(ApplicationDbContext dbContext) : Repository<AuthEntity>(dbContext)
{
    public override List<AuthEntity> Get()
    {
        return DbContext.Auths.ToList() ?? throw new NullReferenceException();
    }

    public override void Update(long id, AuthEntity entity)
    {
        DbContext.Auths
            .Where(predicate: v => v.Id == id)
            .ExecuteUpdate(setPropertyCalls: v => v
                .SetProperty(v => v.Login, entity.Login)
                .SetProperty(v => v.Password, entity.Password));
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }

    #region CreateAuth

    private readonly Random _random = new();

    public AuthEntity AddAuthUser(FIO fio, out ILogger logger)
    {
        if (fio is null) throw new ArgumentNullException();

        var passwords = Get().Select(a => a.Password).ToArray();
        var login = fio?.Surname + _random.Next(10000);

        while (true)
        {
            var password = GenerationPassword(12);
            if (passwords.Length > 0 && passwords.Any(p => BCrypt.Net.BCrypt.Verify(password, p))) continue;

            logger = new AuthLogger(login, password);
            var pass = BCrypt.Net.BCrypt.HashPassword(password);
            return Add(new AuthEntity { Login = login, Password = pass });
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

    public bool Verify(string? login, string? password, out EnterLogger logger)
    {
        var auth = DbContext.Auths.ToList().FirstOrDefault(a => a.Equals(login, password));
        if (auth is null)
        {
            logger = new EnterLogger(null);
            return false;
        }

        logger = new EnterLogger(auth);
        return true;
    }
}
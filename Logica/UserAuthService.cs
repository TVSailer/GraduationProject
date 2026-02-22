using System.Web;

namespace Logica
{
    public static class UserAuthService
    {
        private static Random random = new();

        public static UserAuth CreateAuthUser(string surname, string[] hash)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentNullException();
            
            var login = surname + random.Next(10000);
            var length = 12;

            // ReSharper disable once ComplexConditionExpression
            var password = string.Join("",                                // создаем строку
                Enumerable.Range(0, length)                             // из последовательности длины length
                    .Select(i =>
                        i % 2 == 0 ?                                // на четных местах
                            (char)('A' + random.Next(26)) + "" :    // генерируем букву
                            random.Next(1, 10) + "")              // на нечетных цифру
            );

            var rezult = hash.FirstOrDefault(h => Validatoreg.TryValidPassword(h, password));
        
            return rezult != null ? CreateAuthUser(surname, hash) : new UserAuth(login, password);
        }
    }
}

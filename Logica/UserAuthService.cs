using DataAccess.Postgres;

namespace Logica
{
    public static class UserAuthService
    {
        private static Random rd = new();
        public static UserAuth CreateUser(string surname, string name, ApplicationDbContext dbContext)
        {
            if (string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            
            string login = name + rd.Next(10000);
            string password = null;

            var chare = (surname + name)[rd.Next(surname.Length - 1)];
            foreach (var ch in (surname + name))
            {
                if (ch == chare)
                    password += rd.Next(255);
                password += ch;
            }

            var IsTeacher = dbContext.Teachers.Where(t => t.Login == login || t.Password == password).Count() == 0;

            var IsVisitor = dbContext.Visitors.Where(t => t.Login == login || t.Password == password).Count() == 0;

            if (!IsTeacher && !IsVisitor)
                return CreateUser(surname, name, dbContext);

            return new UserAuth(login, password);
            //return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

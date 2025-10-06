namespace Logica
{
    public class UserAuth
    {
        public UserAuth(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public readonly string? Login;
        public readonly string? Password;
    }
}

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Logica
{
    public static class AdminAuthService
    {
        private const string AdminFilePath = "admin_credentials.json";

        private class AdminData
        {
            public string Login { get; set; }
            public string PasswordHash { get; set; }
            public string Salt { get; set; }
        }

        public static bool CreateAdmin(string login, string password)
        {
            try
            {
                if (File.Exists(AdminFilePath))
                {
                    Message("Администратор уже существует!");
                    return false;
                }

                // Генерируем соль и хешируем пароль
                string salt = GenerateSalt();
                string passwordHash = HashPassword(password, salt);

                var adminData = new AdminData
                {
                    Login = login,
                    PasswordHash = passwordHash,
                    Salt = salt
                };

                string json = JsonSerializer.Serialize(adminData);
                File.WriteAllText(AdminFilePath, json);

                Message("Администратор успешно создан!");
                return true;
            }
            catch (Exception ex)
            {
                Message($"Ошибка: {ex.Message}");
                return false;
            }
        }

        // Метод проверки логина и пароля
        public static bool VerifyAdmin(string login, string password)
        {
            try
            {
                if (!File.Exists(AdminFilePath))
                    return false;

                string json = File.ReadAllText(AdminFilePath);
                var adminData = JsonSerializer.Deserialize<AdminData>(json);

                if (adminData == null || adminData.Login != login)
                    return false;

                // Хешируем введённый пароль с сохранённой солью
                string inputHash = HashPassword(password, adminData.Salt);

                return inputHash == adminData.PasswordHash;
            }
            catch
            {
                return false;
            }
        }

        // Вспомогательные методы для безопасности
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static void Message(object? obj)
        {
            if (obj is string text)
                MessageBox.Show((string)obj, "", MessageBoxButtons.OK);
        }
    }
}


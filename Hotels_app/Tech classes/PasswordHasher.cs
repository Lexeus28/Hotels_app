using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class PasswordHasher
{
    // Размер соли в байтах
    private const int SaltSize = 16;

    // Размер хеша в байтах
    private const int HashSize = 20;

    // Количество итераций
    private const int Iterations = 10000;

    /// <summary>
    /// Асинхронное создание хеша пароля
    /// </summary>
    public static async Task<string> HashPasswordAsync(string password)
    {
        return await Task.Run(() =>
        {
            // Создаем соль
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Создаем хеш
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                var hash = pbkdf2.GetBytes(HashSize);

                // Комбинируем соль и хеш
                var hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                // Конвертируем в base64
                return Convert.ToBase64String(hashBytes);
            }
        });
    }

    /// <summary>
    /// Асинхронная проверка пароля
    /// </summary>
    public static async Task<bool> VerifyPasswordAsync(string password, string hashedPassword)
    {
        return await Task.Run(() =>
        {
            // Конвертируем сохраненный хеш из base64
            var hashBytes = Convert.FromBase64String(hashedPassword);

            // Извлекаем соль
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Создаем хеш введенного пароля
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Сравниваем хеши
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        });
    }
}
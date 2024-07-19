namespace Resume.Core.Security
{
    public class PasswordHelper
    {
        public static string EncodePasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] originalBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(originalBytes);
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}

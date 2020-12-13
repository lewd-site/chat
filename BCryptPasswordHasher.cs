using Chat.Models;
using Microsoft.AspNetCore.Identity;

namespace Chat
{
    public class BCryptPasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password) =>
            BCrypt.Net.BCrypt.HashPassword(password, 10);

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword) =>
            BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword)
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
    }
}

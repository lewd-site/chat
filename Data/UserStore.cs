using Chat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data
{
    public class UserStore : IUserStore<User>, IUserEmailStore<User>, IUserPasswordStore<User>, IQueryableUserStore<User>
    {
        private readonly ChatContext _context;

        public UserStore(ChatContext context)
        {
            _context = context;
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (!int.TryParse(userId, out int id))
            {
                throw new ArgumentException("Integer expected", nameof(userId));
            }

            return _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            string pattern = Regex.Replace(normalizedUserName, @"[%_\\]", @"\$1");
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(user => EF.Functions.ILike(user.Name, pattern), cancellationToken);
        }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            string pattern = Regex.Replace(normalizedEmail, @"[%_\\]", @"\$1");
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(user => EF.Functions.ILike(user.Email, pattern), cancellationToken);
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Name);

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;

            return UpdateAsync(user, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Name.ToUpperInvariant());

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken) =>
            Task.CompletedTask;

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Email);

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;

            return UpdateAsync(user, cancellationToken);
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.EmailConfirmed);

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;

            return UpdateAsync(user, cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Email.ToUpperInvariant());

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken) =>
            Task.CompletedTask;

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.PasswordHash);

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return UpdateAsync(user, cancellationToken);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken) => Task.FromResult(true);

        public IQueryable<User> Users => _context.Users.AsNoTracking();

        public void Dispose() { }
    }
}

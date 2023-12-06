using Microsoft.AspNet.Identity;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Specifications;
using System.Data;


namespace QualicoatManager.Service
{
    public class AuthenticationService
    {
        private readonly IGenericRepository<BaseUser> _userRepo;

        public AuthenticationService(IGenericRepository<BaseUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IBaseUser> ValidateLoginAsync(string username, string password)
        {
            var spec = new UserByUsername(username);

            BaseUser user = await _userRepo.GetEntityWithSpecAsync(spec);

            if (user == null)
            {
                throw new ArgumentNullException("Invalid username.");
            }

            var passwordHasher = new PasswordHasher();

            PasswordVerificationResult passwordMatch = passwordHasher.VerifyHashedPassword(user.Password, password);

            if (passwordMatch == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password.");
            }

            return user;
        }

        public async Task<bool> CreateUser(List<UserRole> roles, string username, string password, string confirmPassword)
        {
            bool success = false;

            if (password == confirmPassword)
            {
                var passwordHasher = new PasswordHasher();

                string hashedPassword = passwordHasher.HashPassword(password);

                //Check user exist
                var userExist = await _userRepo.SearchByNameAsync(username);
                if (userExist != null)
                {
                    throw new Exception("Username already exists!");
                }

                BaseUser user = new BaseUser()
                {
                    Name = username,
                    Password = hashedPassword,
                    UserRoles = roles
                };

                await _userRepo.CreateItemAsync(user);
                success = true;
            }

            return success;
        }
    }
}

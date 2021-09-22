using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;

namespace UserService.Data
{
    public class UserServiceDbContext: IdentityDbContext<User, IdentityRole<long>, long>
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
        {
        }
    }
}
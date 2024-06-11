using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Data.ApplicationIdentity
{
    public class ApplicationIdentityDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {

        }
    }
}

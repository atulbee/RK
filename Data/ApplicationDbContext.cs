using CreativeTim.Argon.DotNetCore.Free.Models;
using CreativeTim.Argon.DotNetCore.Free.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeTim.Argon.DotNetCore.Free.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public DbSet<tblOpCl> tblOpCl { get; set; }
        public DbSet<tblLuckyNumber> tblLuckyNumbers { get; set; }
        public DbSet<CaontactNumbers> CaontactNumberss { get; set; }
    }
}

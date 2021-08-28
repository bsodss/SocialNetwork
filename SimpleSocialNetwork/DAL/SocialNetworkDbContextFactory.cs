using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class SocialNetworkDbContextFactory : IDesignTimeDbContextFactory<SocialNetworkDbContext>
    {
        public SocialNetworkDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SocialNetworkDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\;Database=db;Trusted_Connection=True;",
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new SocialNetworkDbContext(optionsBuilder.Options);
        }
    }

}

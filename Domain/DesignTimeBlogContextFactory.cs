using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Domain;

namespace Blog.Data.EF
{

 
    //dotnet ef migrations add MyFirstMigration
    //dotnet ef database update


    public class DesignTimeBlogContextFactory : IDesignTimeDbContextFactory<RideShareDbContext>
    {
        public RideShareDbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<RideShareDbContext>();

            var connectionString = "Data Source=.\\SQLExpress;Initial Catalog=RideShareDb; TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true";


            dbContextBuilder.UseSqlServer(connectionString);

            return new RideShareDbContext(dbContextBuilder.Options);
        }
    }
}

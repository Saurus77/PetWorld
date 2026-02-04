using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PetWorld.Infrastructure.Data
{
    public class PetWorldDbContextFactory : IDesignTimeDbContextFactory<PetWorldDbContext>
    {
        public PetWorldDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetWorldDbContext>();

            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=petworld;user=root;password=password",
                new MySqlServerVersion(new Version(8, 0, 33)));

            return new PetWorldDbContext(optionsBuilder.Options);
        }
    }
}

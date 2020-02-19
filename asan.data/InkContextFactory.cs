using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace asan.data
{
    public class InkContextFactory : IDesignTimeDbContextFactory<InkContext>
    {
        public InkContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InkContext>();
            optionsBuilder.UseSqlServer("Data Source=MyDatabase");

            return new InkContext(optionsBuilder.Options);
        }
    }
}

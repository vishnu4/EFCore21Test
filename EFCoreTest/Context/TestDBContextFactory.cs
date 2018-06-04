using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTest.Context
{
    public class TestDBContextFactory : IDesignTimeDbContextFactory<TestContext>
    {

        internal const string cnnString = @"Server=localhost\cobraserver;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
     
        public TestContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestContext>();
            builder.UseSqlServer(cnnString);
            return new TestContext(builder.Options);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conectionString = "Server = localhost; Port = 3306; DataBase = dbAPI; Uid = root; Pwd = 1234";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(conectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NexusCanadaTech.Web.API.Repositories
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<NexusRepository>
    {
        //////// 
        public NexusRepository CreateDbContext(string[] args)
        {
            string test = AppDomain.CurrentDomain.BaseDirectory;
            var builder = new DbContextOptionsBuilder<NexusRepository>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.UseSqlServer(configuration.GetConnectionString("WhatrocksConnection"));
            return new NexusRepository(builder.Options);
        }
    }
}

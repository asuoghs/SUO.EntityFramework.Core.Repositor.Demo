using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
 
using SUO.EntityFramework.Core.Repository;
using SUO.Model;

namespace SUO.EntityFramework.Core.Repositor.Demo.Context
{
    /// <summary>
    /// EF Core 上下文
    /// </summary>
    public class MyContext : AbstractDbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });

        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        //{
        //    builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();
        //});

        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            // Database.EnsureCreated();

        }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<UserInfoDetailed> UserInfoDetailed { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Test;User ID=sa;Password=sa;MultipleActiveResultSets=true");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseSqlServer("Data Source=.;Initial Catalog=Test;User ID=sa;Password=sa;MultipleActiveResultSets=true");
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

    }


}

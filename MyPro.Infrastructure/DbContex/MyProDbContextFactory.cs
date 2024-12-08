using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyPro.Infrastructure.DbContex
{
    public class MyProDbContextFactory : IDesignTimeDbContextFactory<MyProDbContext>
    {
        public MyProDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../MyPro.WebApi");

            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("未配置连接字符串。请检查 appsettings.json 中的 ConnectionStrings:DefaultConnection 设置。");
                }

                var optionsBuilder = new DbContextOptionsBuilder<MyProDbContext>();

                optionsBuilder.UseNpgsql(connectionString)
                    .EnableSensitiveDataLogging() // 开启敏感数据日志（仅用于开发环境，生产环境需关闭）
                    .UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole(); // 将日志输出到控制台
                    }));

                return new MyProDbContext(optionsBuilder.Options);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"无法创建 DbContext：{ex.Message}", ex);
            }
        }
    }
}
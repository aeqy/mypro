using Microsoft.EntityFrameworkCore;
using MyPro.Infrastructure.DbContex;

namespace MyPro.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServicesDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            // 配置数据库上下文，使用 PostgreSQL 数据库
            services.AddDbContext<MyProDbContext>(options =>
            {
                // 从配置文件中获取数据库连接字符串，使用 Npgsql 来连接 PostgreSQL 数据库
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            // // 添加数据库健康检查
            // services.AddHealthChecks()
            //     .AddDbContextCheck<MyProDbContext>();

            return services;
        }
    }
}
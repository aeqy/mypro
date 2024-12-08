using Microsoft.OpenApi.Models;

namespace MyPro.WebAPI.Extensions
{
    public static class SwaggerServiceExtensions
    {
        // 扩展方法：为服务集合添加 Swagger 文档生成服务
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // 配置 Swagger 文档信息
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyPro API", // API 标题
                    Version = "v1",     // API 版本
                    Description = "API for managing text entries" // API 描述
                });
            });

            return services; // 返回服务集合以支持链式调用
        }

        // 扩展方法：为应用程序构建器添加 Swagger 中间件
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(); // 启用 Swagger 中间件，生成 API 文档
            app.UseSwaggerUI(c =>
            {
                // 配置 Swagger UI 页面
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyPro API V1"); // 设置 Swagger JSON 端点
            });

            return app; // 返回应用程序构建器以支持链式调用
        }
    }
}
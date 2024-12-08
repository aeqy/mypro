using Microsoft.EntityFrameworkCore;
using MyPro.Application.Interfaces;
using MyPro.Infrastructure.DbContex;
using MyPro.Infrastructure.Repositories;
using MyPro.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 添加控制器服务
builder.Services.AddControllers();

// 加载配置文件
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 配置数据库服务
builder.Services.ConfigureServicesDatabase(builder.Configuration);


// 注册仓储服务
builder.Services.AddScoped<ITextEntryRepository, TextEntryRepository>();

// 使用扩展方法添加 Swagger 服务
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// // 自动迁移数据库
// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<MyProDbContext>();
//     dbContext.Database.Migrate();
// }

// 配置中间件
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // 开发环境异常页面

    // 使用扩展方法启用 Swagger 中间件
    app.UseSwaggerDocumentation();
}


// 使用默认文件中间件
app.UseDefaultFiles();

// 使用静态文件中间件
app.UseStaticFiles();


// 配置路由
app.UseRouting();

// 顶级路由注册
app.MapControllers(); // 映射控制器路由
app.Run();

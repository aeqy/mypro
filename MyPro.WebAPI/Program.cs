using Microsoft.EntityFrameworkCore;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using MyPro.Infrastructure.Data;
using MyPro.Infrastructure.Repositories;
using MyPro.WebAPI.Extensions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// 加载配置文件
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); 

// 配置数据库和
builder.Services.ConfigureServicesDatabase(builder.Configuration);

builder.Services.AddScoped<ITextEntryRepository, TextEntryRepository>();

// 添加健康检查服务
builder.Services.AddHealthChecks()
    .AddDbContextCheck<MyProDbContext>(); // 检查数据库连接

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyProDbContext>();
    dbContext.Database.Migrate();
}

// 配置中间件
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseDefaultFiles(); // 使用默认文件中间件
app.UseStaticFiles();  // 使用静态文件中间件

app.UseRouting();

// 顶级路由注册
app.MapControllers();
app.MapHealthChecks("/health"); // 配置健康检查端点

app.Run();
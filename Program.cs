using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Interface;
using ProjectTest.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Tạo phụ thuộc Interface cho class để tham chiếu => cần thiết để chương trình hiểu nó phụ thuộc vào phần nào
builder.Services.AddScoped<I_ServiceContainer, ContainerService>();
builder.Services.AddScoped<I_AccountService, AccountService>();



// add Builde DB

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DeafautString"));
});

// Cấu hình kết nối angular
//session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; // Chỉ cho phép truy cập qua HTTP
    options.Cookie.IsEssential = true; // Cookie cần thiết cho session
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Chỉ gửi cookie qua HTTPS
});
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Authorization", "Cache-Control", "Content-Type"); // Tùy chọn: Cho phép các headers này xuất hiện trong response
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app Cấu hình kết nối angular
//app.UseCors("AllowAngularApp");

app.UseCors("AllowAllOrigins");
app.UseSession();
// cho phép quyền hạn để truy cập -- khai báo thêm bên controller
app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Options)
    {
        context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
        context.Response.Headers.Append("Access-Control-Allow-Headers", "Authorization, Content-Type, Cache-Control");
        context.Response.StatusCode = 200;
        return;
    }
    await next();
});
//////
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



// Middleware để xử lý Preflight Request (OPTIONS)
app.UseAuthorization();
app.MapControllers();


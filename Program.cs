using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавление службы Razor Pages
builder.Services.AddRazorPages();

// Добавление службы DbContext с подключением к SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Автоматическое создание базы данных
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Если база данных существует, удаляем её
    dbContext.Database.EnsureDeleted();

    // Создаём базу данных заново
    dbContext.Database.EnsureCreated();
}


// Обработка ошибок и безопасность
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Маршрутизация для Razor Pages
app.MapRazorPages();

// Запуск приложения
app.Run();

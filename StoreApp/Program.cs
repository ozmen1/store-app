using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
// using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp")); //migration'ın repositories'de değil de storeapp'te oluşması için.
});

//concrete hallerini ifade ediyoruz. kayıt işlemi yapılıyor. IoC kayıtlarını gerçekleştirmiş olduk.
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

var app = builder.Build();

app.UseStaticFiles(); //uygulama statik dosyalar da kullanabilsin. wwwroot klasörü için.
app.UseHttpsRedirection(); //redirection mekanizmasının çalışması için. uygulamanın belirli bir mantık dahilinde çalışması için.
app.UseRouting(); //routing mekanizmasının çalışması için

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/btk", () => "BTK");
// tek tek yapacağımıza MapControllerRoute kullanacağız.

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{area?}/{controller=Home}/{action=Index}/{id?}"
    //);
    endpoints.MapAreaControllerRoute(
        name: "AdminArea",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    //endpoints.MapAreaControllerRoute(
    //    name: "{areaName}";
    //pattern: "{area}/{controller=Home}/{action=Index}"
    //    );
    //endpoints.MapAreaControllerRoute(
    //    name: "areaRoute",
    //    areaName: "{area:exists}",
    //    pattern: "{areaName}/{controller}/{action}"
    //);
});

//Area yapılanmasını oluştururken buradaki rota yapılanmasını UdeEndpoints'e taşıdık.
// app.MapControllerRoute(
//     name: "default", 
//     pattern: "{controller=Home}/{action=Index}/{id?}"
//     );

app.Run();

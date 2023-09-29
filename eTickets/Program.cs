using System;
using eTickets.Data;
using eTickets.Data.Cart;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

internal class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

        builder.Services.AddScoped<IActorsService, ActorsSevice>();
        builder.Services.AddScoped<IProducersServices, ProducersService>();
        builder.Services.AddScoped<ICinemaServis, CinemasService>();
        builder.Services.AddScoped<IMoviesService, MoviesServise>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped (sc => ShoppingCart.GetShoppingCart(sc));

        builder.Services.AddSession();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        AppDbInitilazer.Seed(app);

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthorization();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        app.Run();

       
    }

}
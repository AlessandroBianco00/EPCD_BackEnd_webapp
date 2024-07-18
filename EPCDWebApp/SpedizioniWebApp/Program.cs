using Microsoft.AspNetCore.Authentication.Cookies;
using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Services;
using SpedizioniWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configurazione dell'autenticazione
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt => {
        // pagina alla quale l'utente sar� indirizzato se non � stato gi� riconosciuto
        opt.LoginPath = "/Account/Login";
    })
    ;
// fine configurazione dell'autenticazione

builder.Services
    .AddAuthorization(opt => {
        opt.AddPolicy(Policies.LoggedIn, cfg => cfg.RequireAuthenticatedUser());
        opt.AddPolicy(Policies.IsAdmin, cfg => cfg.RequireRole("Admin"));
        opt.AddPolicy(Policies.IsBaseUser, cfg => cfg.RequireRole("Cliente"));
    });

builder.Services
    .RegisterDAOs()
    .AddScoped<DbContext>() 
    .AddScoped<IAuthService, AuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using PizzaritoShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core to use SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure session with a 30-minute timeout
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container, including Razor Pages and Memory Cache
builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();


// Configure authentication with cookies
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//});

//User Identity 




// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Use essential middleware
app.UseSession();           // Enable session handling
app.UseHttpsRedirection();  // Redirect HTTP requests to HTTPS
app.UseStaticFiles();       // Serve static files

app.UseRouting();           // Use routing

app.UseAuthentication();    // Ensure this comes before authorization
app.UseAuthorization();     // Use authorization

app.MapRazorPages();        // Map Razor Pages

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();

    // Redirect to /Pizzas/Pizzas when accessing the root URL
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/Pizzas/Pizzas");
        return Task.CompletedTask;
    });
});

// Run the application
app.Run();

using Cart.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//add razor views
builder.Services.AddControllersWithViews(); //add controller with views
//add database services
builder.Services.AddDbContext<Datacontext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductString"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddScoped<Irepository, EFrepository>();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddScoped<Cart.Models.cart>();

//app
var app = builder.Build();
app.MapControllers();
//add route
app.MapControllerRoute(
    name: "default", //default route
    pattern: "{controller=Product}/{action=ProductList}/{id?}"
);
//declare datacontext
app.MapDefaultControllerRoute();
app.MapRazorPages();

//declare fake data
FakeData.SetFakeData(app);
app.Run();

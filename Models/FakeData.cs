using Cart.Models;
using Microsoft.EntityFrameworkCore;

public static class FakeData {
    public static void SetFakeData(IApplicationBuilder app){
        Datacontext ctx = app.ApplicationServices.CreateScope().ServiceProvider.GetService<Datacontext>();

        if(ctx.Database.GetPendingMigrations().Any()) ctx.Database.Migrate();

        if(!ctx.Products.Any()){
            ctx.Products.AddRange(
                new Product{name = "Iphone 13", price = 13000000 },
                
                new Product{name = "Iphone 13", price = 13000000 },
                
                new Product{name = "Iphone 13", price = 13000000 },
                
                new Product{name = "Iphone 13", price = 13000000 },
                
                new Product{name = "Iphone 13", price = 13000000 }
            );
            ctx.SaveChanges();
        }
    }
}
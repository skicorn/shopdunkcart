using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Cart.Models;

namespace Cart.Controllers{
    public class ProductController : Controller{
        private Datacontext datacontext;

        public ProductController(Datacontext datacontext){
            this.datacontext = datacontext;
        }

        public IActionResult ProductList(){
            return View(datacontext.Products);
        }
    }
}
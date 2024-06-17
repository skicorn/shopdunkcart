using Cart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cart.Pages
{
    public class CartModel : PageModel
    {
        private Irepository repository;
        public CartModel(Irepository repository, cart _cart)
        {
           this.repository = repository;
           cart = _cart;
        }
        public cart cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
             ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int id, string returnUrl)
        {
            Product? product = repository.Products
           .FirstOrDefault(item => item.id == id);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToPage(new { ReturnUrl = returnUrl});   
        }
        public IActionResult OnRemove(int id, string returnUrl)
        {
            cart.RemoveItem(cart.CartItems.First(item => item._product.id == id)._product);
            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
    }
}

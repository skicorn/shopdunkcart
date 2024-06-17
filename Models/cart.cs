namespace Cart.Models{
    public class cart{
        public List<CartItem> CartItems { get; set; }
        
        //add a item
        public virtual void AddItem(Product product, int quantity) 
        {
            CartItem? item = CartItems.Where(i => i._product.id == product.id).FirstOrDefault();
            if(item == null){
                CartItems.Add(new CartItem{
                    _product = product,
                    _quantity = quantity
                });
            }
            else item._quantity += quantity;
        }
        public virtual void RemoveItem(Product product) => CartItems.RemoveAll(item => item._product.id == product.id);
        public virtual float Total() => CartItems.Sum(item => item._product.price * item._quantity);
        public virtual void ClearCart() => CartItems.Clear();   
    }
    public class CartItem{
        public int _id { get; set; }
        public Product _product{ get; set; }
        public int _quantity { get; set; }   
    }
}
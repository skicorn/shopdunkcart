namespace Cart.Models{
    public interface Irepository{
        IQueryable<Product> Products { get; }
    }
}
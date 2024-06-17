namespace Cart.Models{
    public class EFrepository : Irepository
    {
        private Datacontext ctx;
        public  EFrepository(Datacontext ctx){
            this.ctx = ctx;
        }
        public IQueryable<Product> Products => ctx.Products;
    } 
}
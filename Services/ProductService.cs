using aspmvc.Models;

namespace aspmvc.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService() {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {ProductId= 1, ProductName="Iphone 15 Pro Max", ProductPrice=200},
                new ProductModel() {ProductId= 2, ProductName="Iphone 14 Pro Max", ProductPrice=300},
                new ProductModel() {ProductId= 3,ProductName="Iphone 13 Pro Max", ProductPrice=400}
            });
        }
    }
}

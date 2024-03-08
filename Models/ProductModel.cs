using Microsoft.AspNetCore.Mvc;

namespace aspmvc.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }       
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
    }
}

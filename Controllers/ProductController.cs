using aspmvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspmvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;
        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index(int? id)
        {
            var product = _productService.Where(p => p.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                TempData["StatusMessage"] = "Not found that product.";
                return Redirect(Url.Action("Index", "Home"));
            }
            return View(product);
        }
    }
}

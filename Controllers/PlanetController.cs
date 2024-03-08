using aspmvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspmvc.Controllers
{
    // Route[(he-mat-troi)]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get;set; }

        //route:  trên route thì luôn có action .../Controller/Action

        // Dùng như thế này để có thể đổi từ Planet/Mercury -> .../[Controller] [Action] [Area]/...
        // [Route(.../[Controller] [Action] [Area]/...) dùng được cho cả action và controller
        // Trong trường hợp khai báo Route ở Controller thì phải khai báo ở Action

        //[HttpGet("/mercury")] chỉ định cho truy cập với route /mercury nhưng chỉ là phương thức get
        //[HttpPost(...)] tương tự
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.NameEn == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.NameEn == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.NameEn == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.NameEn == Name).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}

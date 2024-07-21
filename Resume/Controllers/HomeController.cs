

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("")]
        [HttpGet("/index")]
        [HttpGet("/home/index")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}

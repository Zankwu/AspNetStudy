using HttpClientEg.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientEg.Controllers
{
    public class HomeController : Controller
    {

        private readonly FinnhubService _finnhubService;

        public HomeController(FinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? cnt = await _finnhubService.GetStockPrice("AAPL");
            return Content(Convert.ToString(cnt["c"]));
        }
        [Route("/hello")]
        public async Task<IActionResult> Profile()
        {
            ProfileMySelf pro  = await _finnhubService.GetStockProfile();
            return Content("sda");

        }
    }
}

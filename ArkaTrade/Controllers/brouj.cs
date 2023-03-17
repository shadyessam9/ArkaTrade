using ArkaTrade.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArkaTrade.Controllers
{
    public class brouj : Controller
    {
        arkatradeContext _entity;
        private readonly ILogger<HomeController> _logger;
        public brouj(ILogger<HomeController> logger, arkatradeContext _entity)
        {
            this._entity = _entity;
            _logger = logger;
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}

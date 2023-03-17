using ArkaTrade.Data;
using ArkaTrade.Models;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArkaTrade.Controllers
{
    public class gallery : Controller
    {

        arkatradeContext _entity;
        private readonly ILogger<HomeController> _logger;
        public gallery(ILogger<HomeController> logger, arkatradeContext _entity)
        {
            this._entity = _entity;
            _logger = logger;
        }

        public IActionResult Index()
        {



            var list1 = (from imgs in _entity.Images
                         select new Image
                         {
                             FileName = imgs.FileName,
                             ContentType = imgs.ContentType,
                             Data = imgs.Data,
                             dept = imgs.dept
                         }).ToList();


            var ViewModel = new viewlists()
            {
                images = list1,

            };

            return View(ViewModel);
        }
    }
}

using ArkaTrade.Data;
using ArkaTrade.Models;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace ArkaTrade.Controllers
{
    public class barakat : Controller
    {


        arkatradeContext _entity;
        public barakat(arkatradeContext _entity)
        {
            this._entity = _entity;
        }

        public IActionResult Index()
        {


            var list1 = (from imgs in _entity.Images where imgs.dept == "ElBarakat"
                         select new Image
                         {
                             FileName = imgs.FileName,
                             ContentType = imgs.ContentType,
                             Data = imgs.Data,
                             dept = imgs.dept
                         }).ToList();


            var ViewModel = new viewlists()
            {
                images = list1


            };


            return View(ViewModel);
        }
    }
}

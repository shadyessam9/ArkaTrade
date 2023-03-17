using ArkaTrade.Data;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArkaTrade.Controllers
{
    public class blog : Controller
    {
        arkatradeContext _entity;
        public blog(arkatradeContext _entity)
        {
            this._entity = _entity;
        }

        public IActionResult Index()
        {



            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");


            var posts = (from blgs in _entity.blogs.Where(b => b.until >= DateTime.Parse(currentDate))
                         
                         select new Models.blog
                         {
                             title = blgs.title,
                             img = blgs.img,
                             until = blgs.until,
                             ContentType = blgs.ContentType,
                             description = blgs.description
                         }).ToList();


            var ViewModel = new viewlists()
            {
                blogs = posts
            };

            return View(ViewModel);
        }
    }
}

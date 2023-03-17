using ArkaTrade.Data;
using ArkaTrade.Models;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ArkaTrade.Controllers
{
    public class HomeController : Controller
    {

		arkatradeContext _entity;
        public HomeController(arkatradeContext _entity)
        {
			this._entity = _entity;
        }


		public IActionResult Index()
        {

            var list1 =  _entity.Images.GroupBy(x => x.dept).Select(group => new{
                Category = group.Key,
                Values = group.Take(4)
            }).ToList();


            var list2 = (from cntrs in _entity.countries where cntrs.show == 1
                         select new country
                         {
                             code = cntrs.code,
                         }).ToList();


            var ViewModel = new viewlists()
            {
                Categories = list1.Select(x => x.Category).ToList(),
                Values = list1.SelectMany(x => x.Values).ToList(),
                countries = list2
            };
			return View(ViewModel);
        }



        public IActionResult meta()
        {

            var phons = (from p in _entity.phones
                         select new phone
                         {
                             id = p.id,
                             phone1 = p.phone1,
                         }).ToList();


            var mils = (from m in _entity.mails
                        select new mail
                        {
                            id = m.id,
                            email = m.email,
                        }).ToList();


            var locs = (from l in _entity.locations
                        select new location
                        {
                            id = l.id,
                            location1 = l.location1,
                        }).ToList();


            return Json(new { phones = phons, mails = mils , locations = locs });
        }


        [HttpPost]
        public ActionResult addemail(string email)
        {
            var eml = new email
            {
                email1 = email,
            };

            _entity.emails.Add(eml);
            _entity.SaveChanges();  
            
            return Json(new { success = true });
        }


    }
}
using ArkaTrade.Data;
using ArkaTrade.Models;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace ArkaTrade.Controllers
{
    public class contact : Controller
    {
        arkatradeContext _entity;
        private readonly ILogger<HomeController> _logger;
        public contact(ILogger<HomeController> logger, arkatradeContext _entity)
        {
            this._entity = _entity;
            _logger = logger;
        }

        public IActionResult Index()
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


            var ViewModel = new viewlists()
            {
                phones = phons,
                mails = mils,
                locations = locs
            };

            return View(ViewModel);
        }


    }
}

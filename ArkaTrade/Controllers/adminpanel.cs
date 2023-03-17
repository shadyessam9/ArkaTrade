using ArkaTrade.Data;
using ArkaTrade.Models;
using ArkaTrade.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ArkaTrade.Controllers
{
    public class adminpanel : Controller
    {



        arkatradeContext _entity;
        private readonly ILogger<HomeController> _logger;
        public adminpanel(ILogger<HomeController> logger, arkatradeContext _entity)
        {
            this._entity = _entity;
            _logger = logger;
        }

        [HttpGet]
        [PasswordActionFilter("1234")]
        public IActionResult Index()
        {

            var list1 = (from cntrs in _entity.countries
                         select new country
                         {
                             countryname= cntrs.countryname,
                             code = cntrs.code,
                             show = cntrs.show
                         }).ToList();

            var list2 = (from imgs in _entity.Images
                         select new Image
                         {
                             FileName = imgs.FileName,
                             ContentType = imgs.ContentType,
                             Data = imgs.Data,
                             dept = imgs.dept,
                             Id= imgs.Id
                         }).ToList();


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


            var ViewModel = new viewlists(){ 
                countries = list1,
                phones = phons,
                mails = mils,
                locations = locs,
                images = list2,

            };

            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> images,string dept)
        {
            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var contentType = image.ContentType;
                    

                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        var data = stream.ToArray();

                        var model = new Image
                        {
                            FileName = fileName,
                            ContentType = contentType,
                            Data = data,
                            dept= dept
                        };

                        _entity.Images.Add(model);
                    }
                }
            }

            await _entity.SaveChangesAsync();

            return Content("<script>alert('Done');</script>", "text/html");
        }



        [HttpPost]

        public IActionResult deleteimage(int id)
        {
            var img= _entity.Images.FirstOrDefault(p => p.Id == id);
            _entity.Images.Remove(img);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }




        [HttpPost]
        public IActionResult Updatecountries(string[] SelectedCountries)
        {

            var countries = _entity.countries.ToList();
            foreach (var country in countries)
            {
                country.show = SelectedCountries != null && SelectedCountries.Contains(country.countryname) ? 1 : 0;
                _entity.Update(country);
            }
            _entity.SaveChanges();


            return base.Content("<script>alert('Done');</script>", "text/html");
        }







        [HttpPost]
        public async Task<IActionResult> Addpost(IFormFile image ,Models.blog post)
        {


            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                var data = stream.ToArray();
                var contentType = image.ContentType;

                var blg = new Models.blog
                {
                    title = post.title,
                    img = data,
                    ContentType= contentType,
                    description = post.description,
                    until = post.until
                };

                _entity.blogs.Add(blg);
                _entity.SaveChanges();
            }

            return Content("<script>alert('Done');</script>", "text/html");
        }









        [HttpPost]

        public IActionResult deletephone(int id)
        {
            var phn = _entity.phones.FirstOrDefault(p => p.id == id);
            _entity.phones.Remove(phn);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }


        [HttpPost]

        public IActionResult deletemail(int id)
        {
            var mil = _entity.mails.FirstOrDefault(p => p.id == id);
            _entity.mails.Remove(mil);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }


        [HttpPost]

        public IActionResult deletelocation(int id)
        {
            var loc = _entity.locations.FirstOrDefault(p => p.id == id);
            _entity.locations.Remove(loc);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }




        [HttpPost]

        public IActionResult addphone(string phone)
        {
            var phn = new phone
            {
                phone1 = phone,
            };
            _entity.phones.Add(phn);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }


        [HttpPost]

        public IActionResult addmail(string mail)
        {
            var mil = new mail
            {
                email = mail,
            };
            _entity.mails.Add(mil);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }


        [HttpPost]

        public IActionResult addlocation(string location)
        {
            var loc = new location
            {
                location1 = location,
            };
            _entity.locations.Add(loc);
            _entity.SaveChanges();
            return RedirectToAction("Index", "adminpanel");
        }





        [HttpGet]
        public async Task<IActionResult> DownloadData()
        {
            // Query the database to retrieve the data
            var data = await _entity.emails.ToListAsync();

            // Format the data as a tab-separated text file
            var fileContent = new StringBuilder();
            foreach (var item in data)
            {
                fileContent.AppendLine($"{item.email1}");
            }

            // Return the file as a download
            return File(Encoding.UTF8.GetBytes(fileContent.ToString()), "text/plain", "emails.txt");
        }

    }
}

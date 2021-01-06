using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace OurCms.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        OurCmsContext db = new OurCmsContext();
            public SearchController()
        {
            pageRepository = new PageRepository(db); 
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace OurCms.Controllers
{
    public class NewsController : Controller
    {
        OurCmsContext db = new OurCmsContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }
        
        public ActionResult ShoeGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }

        public ActionResult ShowGroupInSlider()
        {
            return PartialView(pageGroupRepository.GetAllPageGroup());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.GetTopPages());
        }

        public ActionResult LatesNews()
        {
            return PartialView(pageRepository.GetLateNews());
        }

        [Route("Archiv")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPages());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id,string title)
        {
            ViewBag.name = title;
            return View(pageRepository.GEtShowGroupByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var News = pageRepository.GetPageById(id);
            if (News == null)
            {
                return HttpNotFound();
            }
            News.Visit += 1;
            pageRepository.UpdatePage(News);
            pageRepository.Save();
            
            return View(News);
        }

        public ActionResult AddComment(int id,string name,string email,string comment)
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID= id,
                Name=name,
                Email=email,
                Comment=comment
            };
            pageCommentRepository.AddComment(addcomment);
            return PartialView("ShowComment",pageCommentRepository.GetCommentByNewsId(id));

        }

        public ActionResult ShowComment(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }
    }
}
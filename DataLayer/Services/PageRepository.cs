using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private OurCmsContext db;
        public PageRepository(OurCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPages()
        {
           return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            var g = GetPageById(pageId);
            DeletePage(g);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Page> GetTopPages(int take = 4)
        {
            return db.Pages.OrderByDescending(g=>g.Visit).Take(take);
        }

        public IEnumerable<Page> GetPageInSlider()
        {
            return db.Pages.Where(g => g.ShowInSlider == true);
        }

        public IEnumerable<Page> GetLateNews(int take = 4)
        {
            return db.Pages.OrderByDescending(g=>g.CreateDate).Take(take);
        }

        public IEnumerable<Page> GEtShowGroupByGroupId(int groupId)
        {
           return(db.Pages.Where(g=>g.GroupID==groupId));
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return db.Pages.Where(g => g.Title.Contains(search) || g.ShortDescription.Contains(search) || g.Text.Contains(search) || g.Tags.Contains(search)).Distinct();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        
    }
}

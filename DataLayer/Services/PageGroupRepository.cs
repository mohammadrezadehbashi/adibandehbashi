using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private OurCmsContext db;
        public PageGroupRepository(OurCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<PageGroup> GetAllPageGroup()
        {
            return db.PageGroups;
        }

        public PageGroup GetGroupById(int pageId)
        {
            return db.PageGroups.Find(pageId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true; 
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(int pageId)
        {
            var g = GetGroupById(pageId);
            DeleteGroup(g);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForView()
        {
            return db.PageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count

            });
        }

        public void Dispose()
        {
           db.Dispose();
        }

        
    }
}

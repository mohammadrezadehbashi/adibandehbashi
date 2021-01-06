using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{ 
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();

        IEnumerable<Page> GetTopPages(int take = 4);
        IEnumerable<Page> GetPageInSlider();
        IEnumerable<Page> GetLateNews(int take=4);
        IEnumerable<Page> GEtShowGroupByGroupId(int groupId);
        IEnumerable<Page> SearchPage(string search);
    }
}

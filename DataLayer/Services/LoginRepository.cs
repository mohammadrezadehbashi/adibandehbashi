using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        private OurCmsContext db;
        public LoginRepository(OurCmsContext context)
        {
            db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogins.Any(f => f.UserName == username && f.Password== password);
        }
    }
}

using System.Web.Mvc;
using ERP_Viewer.Data.Models;
using ERP_Viewer.Web.Models;
using Microsoft.AspNet.Identity;

namespace ERP_Viewer.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext userDb = new ApplicationDbContext();
        protected CompanyDataEntities companyDb = new CompanyDataEntities();

        public bool isAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.User.IsInRole("Administrator");
            return isAdmin;
        }
    }
}
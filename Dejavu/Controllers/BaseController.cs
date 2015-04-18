using System.Web.Mvc;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class BaseController : Controller
    {
        private readonly OpenAccessContext _context;

        public BaseController(OpenAccessContext context)
        {
            _context = context;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if(!filterContext.IsChildAction && _context != null && filterContext.Exception == null)
                _context.SaveChanges();
        } 
    }
}
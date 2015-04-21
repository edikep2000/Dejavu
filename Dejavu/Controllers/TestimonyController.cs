using System.Web.Mvc;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class TestimonyController : BaseController
    {
        public TestimonyController(OpenAccessContext context) : base(context)
        {
        }

        public ActionResult New()
        {
            return null;
        }
    }
}
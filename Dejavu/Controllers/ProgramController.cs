using System.Threading.Tasks;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;

namespace Dejavu.Controllers
{
    public class ProgramController : Controller
    {
        private readonly ProgramService _programService;

        public ProgramController(ProgramService programService)
        {
            _programService = programService;
        }

        public async  Task<ActionResult> Details(int id)
        {
            var m = await _programService.GetSingle(id);
            var model = new ProgramListModel()
                {
                    BannerUrl = m.BannerUrl,
                    DateCreated = m.DateCreated,
                    DateHeld = m.DateHeld,
                    Description = m.Description,
                    Id = m.Id,
                    Name = m.Name,
                    TestimonyCount = m.ProgramTestimonies.Count,
                    ReviewCount = m.ProgramReviews.Count
                };
            return View(model);
        }
    }
}
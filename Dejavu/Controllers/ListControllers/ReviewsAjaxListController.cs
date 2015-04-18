using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Kendo.Mvc.Extensions;
using Omu.AwesomeMvc;

namespace Dejavu.Controllers.ListControllers
{
    public class ReviewsAjaxListController : Controller
    {
        private readonly ProgramReviewsService _reviewService;

        public ReviewsAjaxListController(ProgramReviewsService ratingsService)
        {
            _reviewService = ratingsService;
        }

        public async Task<ActionResult> GetForProgram(string search, int page, int programId)
        {
            var item = await _reviewService.GetForProgram(programId);
            var list = item.Select(i => new ProgramReviewsViewModel
                {
                    Id = i.Id,
                    Chapter = i.Chapter,
                    DateCreated = i.DateCreated,
                    PostedBy = i.PostedBy,
                    ProgramId = i.ProgramId,
                    Review = i.Review
                }).OrderByDescending(i => i.DateCreated).ThenByDescending(i => i.Id);
            return Json(new AjaxListResult()
                {
                    Content = this.RenderView("ListTemplates/_reviewListTemplate", list.Page(page, 7)),
                    More = list.Count() > page*7
                });
        }
    }
}

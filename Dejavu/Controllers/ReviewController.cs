using System.Threading.Tasks;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Dejavu.Models;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly ProgramReviewsService _reviewService;
        public ReviewController(OpenAccessContext context, ProgramReviewsService reviewService) : base(context)
        {
            _reviewService = reviewService;
        }

        public PartialViewResult New(int id)
        {
            var model = new ProgramReviewsEditorModel
                {
                    ProgramId = id
                };
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(ProgramReviewsEditorModel model)
        {
            if (ModelState.IsValid)
            {
                var m = AutoMapper.Mapper.Map<ProgramReviews>(model);
                await _reviewService.Insert(m);
                return Json(new {});

            }
            return PartialView(model);
        }
    }
}
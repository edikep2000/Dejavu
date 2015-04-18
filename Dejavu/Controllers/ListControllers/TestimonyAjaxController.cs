using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Kendo.Mvc.Extensions;
using Omu.AwesomeMvc;

namespace Dejavu.Controllers.ListControllers
{
    public class TestimonyAjaxController : Controller
    {
        private readonly ProgramTestimoniesService _testimoniesService;

        public TestimonyAjaxController(ProgramTestimoniesService testimoniesService)
        {
            _testimoniesService = testimoniesService;
        }

        public async Task<ActionResult> GetAll(int page)
        {
            var model = await _testimoniesService.GetAll();
            var l = model.Select(i => new TestimonyViewModel
                {
                    Id = i.Id,
                    Post = i.Post,
                    PostedBy = i.PostedBy,
                    DatePosted = i.DatePosted,
                    Likes = i.Likes,
                    ProgramId = i.ProgramId
                }).OrderByDescending(I => I.DatePosted).ThenByDescending(i => i.Likes);
            return Json(new AjaxListResult
                {
                    Content = this.RenderView("ListTemplates/_testimonyListTemplate", l.Page(page, 10)),
                    More = l.Count() > page*10
                });
        }

        public async Task<JsonResult> GetForProgram(int id, int page)
        {
            var model = await _testimoniesService.GetAll(id);
            var l = model.Select(i => new TestimonyViewModel
            {
                Id = i.Id,
                Post = i.Post,
                PostedBy = i.PostedBy,
                DatePosted = i.DatePosted,
                Likes = i.Likes,
                ProgramId = i.ProgramId
            }).OrderByDescending(I => I.DatePosted).ThenByDescending(i => i.Likes);
            return Json(new AjaxListResult
            {
                Content = this.RenderView("ListTemplates/_testimonyListTemplate", l.Page(page, 10)),
                More = l.Count() > page * 10
            });
        }
    }
}
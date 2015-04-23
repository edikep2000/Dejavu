using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dejavu.Common.Extensions;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Omu.AwesomeMvc;

namespace Dejavu.Controllers.ListControllers
{
    public class ProgramAjaxListController : Controller
    {
        private readonly ProgramService _programService;

        public ProgramAjaxListController(ProgramService programService)
        {
            _programService = programService;
        }

        public async Task<ActionResult> GetPrograms(string search, int page)
        {
            var list = await _programService.GetAll();
            var s =
                list.Where(i => i.Name.Contains(search)).Select(i => new ProgramListModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        DateCreated = i.DateCreated,
                        RatingsCount = i.ProgramRatings.Count(),
                        ReviewCount = i.ProgramReviews.Count(),
                        TestimonyCount = i.ProgramTestimonies.Count(),
                        BannerUrl = i.BannerUrl,
                        DateHeld = i.DateHeld,
                    }).OrderByDescending(i => i.DateHeld)
                    .ThenByDescending(i => i.DateCreated).ThenByDescending(I => I.RatingsCount);
            return Json(new AjaxListResult
                {
                    Content = this.RenderView("ListTemplates/_programListTemplate", list.Page(page, 5)),
                    More = list.Count() > page*5
                });
        }

        public  ActionResult GetProgramsForHome(string search, int page)
        {
            search = (search ?? "").ToLower();
            var list =  _programService.GetAll().Result.Where(i => i.Name.Contains(search));
            var s =
               list.Select(i => new ProgramListModel
               {
                   Id = i.Id,
                   Name = i.Name,
                   DateCreated = i.DateCreated,
                   ReviewCount = i.ProgramReviews.Count(),
                   TestimonyCount = i.ProgramTestimonies.Count(),
                   BannerUrl = i.BannerUrl,
                   DateHeld = i.DateHeld,
                   Description = i.Description
               }).OrderByDescending(i => i.DateHeld)
                   .ThenByDescending(i => i.DateCreated).ThenByDescending(I => I.TestimonyCount).AsEnumerable();
            var programListModels = s as IList<ProgramListModel> ?? s.ToList();
            return Json(new AjaxListResult
            {
                Content = this.RenderView("ListTemplates/_homeProgramListPartial", programListModels.Page(page, 1)),
                More = programListModels.Count() > page * 1
            });

        }
    }
}
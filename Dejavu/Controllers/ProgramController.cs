using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Dejavu.Models;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class ProgramController : BaseController
    {
        private readonly ProgramService _programService;


        public ProgramController(OpenAccessContext context, ProgramService programService) : base(context)
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

        public async Task<ActionResult> Edit(int id)
        {
            var program = await _programService.GetSingle(id);
            var M = new ProgramEditorModel()
                {
                    BannerUrl = program.BannerUrl,
                    DateCreated = program.DateCreated,
                    DateHeld = program.DateHeld,
                    Description = program.Description,
                    Id = program.Id,
                    Name = program.Name,
                    VideoUrl = program.VideoUrl
                };
            return View(M);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Edit(ProgramEditorModel model, HttpPostedFileBase files)
        {
            if (ModelState.IsValid)
            {
                var persistentEntity = await _programService.GetSingle(model.Id);
                var imageUploadPath = Server.MapPath("~/Uploads");
                string bannerUrl = String.Empty;
               if (files != null)
               {
                   var extension = Path.GetExtension(files.FileName);
                   if (!(files.FileName.EndsWith(".png") || files.FileName.EndsWith(".jpg")))
                   {
                       ModelState.AddModelError("files", "Image must be of Jpg or Png type");
                       return View(model);
                   }
                   var fileName = model.Name + "." + extension;
                   bannerUrl = "/Uploads/" + fileName;
                   files.SaveAs(Path.Combine(imageUploadPath, fileName));
               }
                if (persistentEntity != null)
                {
                    if(!String.IsNullOrEmpty(bannerUrl))
                        persistentEntity.BannerUrl = bannerUrl;
                    persistentEntity.Name = model.Name;
                    persistentEntity.Description = model.Description;
                    persistentEntity.VideoUrl = model.VideoUrl;
                    TempData["Message"] = "Event details Saved Successfully";
                    return RedirectToAction("Edit", new { id = model.Id });
                }
             ModelState.AddModelError("","Cannot save changes to an event that does not exist anymore");
            }
           
            return View(model);
        }
    }
}
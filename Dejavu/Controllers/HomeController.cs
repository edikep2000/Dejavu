using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Dejavu.Models;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ProgramService _persistenceService;
        private readonly ProgramTestimoniesService _testimoniesService;

        public HomeController(OpenAccessContext context, ProgramService persistenceService, ProgramTestimoniesService testimoniesService) : base(context)
        {
            _persistenceService = persistenceService;
            _testimoniesService = testimoniesService;
        }

        [Authorize]
        public ActionResult Program()
       {
           return View();
       }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Program(ProgramEditorModel model, HttpPostedFileBase files)
        {
            if (ModelState.IsValid)
            {
                var persistentEntity = AutoMapper.Mapper.Map<Program>(model);
                var imageUploadPath = Server.MapPath("~/Uploads");
                if (files == null)
                {
                    ModelState.AddModelError("files", "You must specify a Banner URL");
                    return View(model);
                }
                var extension = Path.GetExtension(files.FileName);
                if (!(files.FileName.EndsWith(".png") || files.FileName.EndsWith(".jpg")))
                {
                    ModelState.AddModelError("files", "Image must be of Jpg or Png type");
                    return View(model);

                }
                var fileName = model.Name + "." + extension;
                var bannerUrl = "/Uploads/" + fileName;
                files.SaveAs(Path.Combine(imageUploadPath, fileName));
                //we have saved the image
                persistentEntity.BannerUrl = bannerUrl;
                persistentEntity.DateCreated = DateTime.Now;
                await  _persistenceService.Insert(persistentEntity);
                TempData["Message"] = "Event details Saved Successfully";
                return RedirectToAction("Program");
            }
            return View(model);
        }


        public ActionResult Index()
        {
            var testimonyTask = _testimoniesService.GetAll();
            var programTask = _persistenceService.GetAll();
            var m = new ShareModel
                {
                    ProgramCount = programTask.Result.Count(),
                    TestimonyCount = testimonyTask.Result.Count()
                };
            return View(m);
        }
    }
}

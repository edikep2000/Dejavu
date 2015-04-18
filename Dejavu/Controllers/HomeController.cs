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
        public HomeController(OpenAccessContext context, ProgramService persistenceService) : base(context)
        {
            _persistenceService = persistenceService;
        }

        public ActionResult Program()
       {
           return View();
       }

        [HttpPost]
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
                var bannerUrl = "~/Uploads/" + fileName;
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
            return View();
        }

        public  ActionResult Trending()
        {
            return View();
        }
    }
}

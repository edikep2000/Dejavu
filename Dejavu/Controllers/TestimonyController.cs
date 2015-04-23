using System;
using System.Web.Mvc;
using Dejavu.Common.ViewModels;
using Dejavu.DataAccess.Service;
using Dejavu.Models;
using Telerik.OpenAccess;

namespace Dejavu.Controllers
{
    public class TestimonyController : BaseController
    {
        private readonly ProgramTestimoniesService _testimonyService;
        public TestimonyController(OpenAccessContext context, ProgramTestimoniesService testimonyService) : base(context)
        {
            _testimonyService = testimonyService;
        }

        [HttpPost]
        public ActionResult New(TestimonyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var m = AutoMapper.Mapper.Map<ProgramTestimonies>(model);
                m.DatePosted = DateTime.Now;
                _testimonyService.Insert(m);
                return Json(new { });
            }
            return Json(new {});
        }
    }
}
using AutoMapper;
using Dejavu.Common.ViewModels;
using Dejavu.Models;

namespace Dejavu.App_Start
{
    public class DefaultProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Program, ProgramViewModel>()
                  .ForSourceMember(m => m.ProgramRatings, c => c.Ignore())
                  .ForSourceMember(m => m.ProgramReviews, c => c.Ignore())
                  .ForSourceMember(m => m.ProgramTestimonies, c => c.Ignore());
            Mapper.CreateMap<ProgramViewModel, Program>()
                  .ForMember(c => c.ProgramRatings, c => c.Ignore())
                  .ForMember(c => c.ProgramReviews, c => c.Ignore())
                  .ForMember(c => c.ProgramTestimonies, c => c.Ignore());


            Mapper.CreateMap<Program, ProgramEditorModel>()
                  .ForSourceMember(m => m.ProgramRatings, c => c.Ignore())
                  .ForSourceMember(m => m.ProgramReviews, c => c.Ignore())
                  .ForSourceMember(m => m.ProgramTestimonies, c => c.Ignore());

            Mapper.CreateMap<ProgramEditorModel, Program>()
                  .ForMember(c => c.ProgramRatings, c => c.Ignore())
                  .ForMember(c => c.ProgramReviews, c => c.Ignore())
                  .ForMember(c => c.ProgramTestimonies, c => c.Ignore());

            Mapper.CreateMap<ProgramReviews, ProgramReviewsEditorModel>()
                  .ForSourceMember(m => m.Program, c => c.Ignore());

            Mapper.CreateMap<ProgramReviewsEditorModel, ProgramReviews>()
                  .ForMember(m => m.Program, c => c.Ignore());

            Mapper.CreateMap<ProgramTestimonies, TestimonyViewModel>()
                  .ForSourceMember(m => m.Program, c => c.Ignore());
            Mapper.CreateMap<TestimonyViewModel, ProgramTestimonies>()
                  .ForMember(m => m.Program, C => C.Ignore());
        }
    }
}
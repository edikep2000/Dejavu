using AutoAutoMapper;
using AutoMapper;
using Dejavu.Common.ViewModels;
using Dejavu.Models;

namespace Dejavu.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterProfiles()
        {
            // To register your AutoMapper profiles, add the following line
            // to the Application_Start method in your Global.asax file:
            // AutoMapperConfig.RegisterProfiles();

            // By default, AutoAutoMapper will only look for Profiles in the assembly
            // that calls it (internally it uses Assembly.GetCallingAssembly()).
            // This means if you call this method via Application_Start in Global.asax,
            // only your web project will be scanned for AutoMapper.Profile implementations.
            // If you define AutoMapper.Profile classes in any other assemblies, see
            // below for instructions on how to tell AutoAutoMapper to scan those assemblies.
            AutoProfiler.RegisterProfiles();

            // If your AutoMapper Profile classes are defined in a different assembly,
            // you can register them by passing an assembly argument:
            //AutoProfiler.RegisterProfiles(Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)));

            // If you have AutoMapper Profile classes defined in multiple assemblies,
            // you can pass multiple assembly arguments:
            // AutoProfiler.RegisterProfiles(Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)),
            //    Assembly.GetAssembly(typeof(SomeAutoMapperProfileClassInADifferentAssembly)));

            // Additionally, there is a RegisterProfiles overload that takes an
            // IEnumerable<Assembly> if you wish to pass all assemblies at once:
            // var assemblies = new[]
            //     {
            //         Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)),
            //         Assembly.GetAssembly(typeof(SomeAutoMapperProfileClassInADifferentAssembly)),
            //     };
            // AutoProfiler.RegisterProfiles(assemblies);
        }
    }

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

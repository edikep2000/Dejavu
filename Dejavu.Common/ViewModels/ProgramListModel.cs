using System;

namespace Dejavu.Common.ViewModels
{
    public class ProgramListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateHeld { get; set; }

        public DateTime DateCreated { get; set; }

        public int RatingsCount { get; set; }

        public String Description { get; set; }

        public int ReviewCount { get; set; }

        public int TestimonyCount { get; set; }

        public string BannerUrl { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Dejavu.Common.ViewModels
{
    public  class ProgramViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Program Title")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date Held")]
        [Required]
        public DateTime DateHeld { get; set; }

        [Display(Name = "Banner Url")]
        [Required]
        public String BannerUrl { get; set; }

        [Display(Name = "Video Url")]
  
        public String VideoUrl { get; set; }

        [Display(Name = "Date Created")]
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
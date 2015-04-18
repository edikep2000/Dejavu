using System;
using System.ComponentModel.DataAnnotations;

namespace Dejavu.Common.ViewModels
{
    public class ProgramReviewsViewModel
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Posted By")]
        [Required]
        public string PostedBy { get; set; }

        [Display(Name = "Chapter")]
        [Required]
        public string Chapter { get; set; }
        
        [Display(Name = "Your Review")]
        [Required]
        [StringLength(250)]
        public string Review { get; set; }

        [Required]
        [Display(Name = "Program Id")]
        public int ProgramId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
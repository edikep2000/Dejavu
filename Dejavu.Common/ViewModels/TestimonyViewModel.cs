using System;
using System.ComponentModel.DataAnnotations;

namespace Dejavu.Common.ViewModels
{
    public class TestimonyViewModel
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public String PostedBy { get; set; }

        [Display(Name = "Posted On")]
        public DateTime DatePosted { get; set; }

        [Display(Name = "Testimony0")]
        [Required]
        [StringLength(255)]
        public String Post { get; set; }

        [Display(Name = "Likes")]
        public long Likes { get; set; }

        [Display(Name = "Chapter")]
        [Required]
        public String Chapter { get; set; }

        [Display(Name = "ProgramId")]
        [Required]
        public long ProgramId { get; set; }
    }
}
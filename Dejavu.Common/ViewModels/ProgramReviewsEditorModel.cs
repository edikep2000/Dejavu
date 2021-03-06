﻿using System.ComponentModel.DataAnnotations;

namespace Dejavu.Common.ViewModels
{
    public class ProgramReviewsEditorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public string PostedBy { get; set; }


        [Display(Name = "Chapter")]
        [StringLength(100)]
        public string Chapter { get; set; }

        [Display(Name = "Review")]
        [StringLength(200)]
        [Required]
        public string Review { get; set; }

        [Display(Name = "Program")]
        [Required]
        public int ProgramId { get; set; }
        
    }
}
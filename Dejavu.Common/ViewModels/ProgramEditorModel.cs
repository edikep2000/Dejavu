using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dejavu.Common.ViewModels
{
  public  class ProgramEditorModel
    {

      [Key]
      public int Id { get; set; }

      [Required]
      public String Name { get; set; }

      [Display(Name = "Date Held")]
      [Required]
      public DateTime DateHeld { get; set; }

      [Display(Name = "Banner Url")]
      public String BannerUrl { get; set; }


      [Display(Name = "Youtube Video Url")]
      [RegularExpression(@"(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|watch\?.+&v=))((\w|-){11})(?:\S+)?", ErrorMessage="Invalid Youtube Video URL Format")]
      public String VideoUrl { get; set; }

      [Display(Name = "Date Created")]
      public DateTime DateCreated { get; set; }
    }
}

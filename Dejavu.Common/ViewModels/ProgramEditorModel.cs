using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dejavu.Common.ViewModels
{
  public  class ProgramEditorModel
    {

      public int Id { get; set; }

      public String Name { get; set; }

      public DateTime DateHeld { get; set; }

      public String BannerUrl { get; set; }

      public String VideoUrl { get; set; }

      public DateTime DateCreated { get; set; }
    }
}

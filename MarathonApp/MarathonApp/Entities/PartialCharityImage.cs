using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonApp.Entities
{
   public partial class Charity   
    {
        public string SourcePath => AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Assets\\Charities\\" + CharityLogo;
    }
}

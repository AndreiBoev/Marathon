using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonApp.Entities
{
    public partial class RegistrationEvent
    {
        public string FullRunnerName => Registration.FullRunner + "-" + BibNumber + " (" + Registration.Runner.CountryCode + ")";
    }
}

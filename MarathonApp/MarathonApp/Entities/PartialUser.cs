﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonApp.Entities
{
    public partial class User
    {
        public string FullName => LastName + " " + FirstName;
    }
}

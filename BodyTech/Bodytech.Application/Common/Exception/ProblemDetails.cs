using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Common.Exception
{
    public class ProblemDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }
}
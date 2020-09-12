using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.ViewModels
{
    public class UploadViewModel
    {

        public IEnumerable<filters> filters { get; set; }
        public Works Works { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class filters
    {
        [Key]
        public int Id { get; set; }

        public string Filter { get; set; }
    }
}
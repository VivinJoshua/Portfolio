using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class Works
    {
        [Key]
        public int Id { get; set; }

        public string Filter { get; set; }
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Work")]
        public byte[] Image { get; set; }

        public DateTime? DT { get; set; }



    }
}
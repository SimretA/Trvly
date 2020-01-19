using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trvly.Models
{
    public class BlogPost
    {
        public int id { get; set; }
        public String PostedBy { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Body { get; set; }
        //public byte[] Image { get; set; }
        public Boolean IsApproved { get; set; }

    }
}
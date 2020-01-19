using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trvly.Models
{
    public class Tour
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public float Price { get; set; }

        public Tour(int id, String Title, String Description, int Days, float Price) {
            this.id = id;
            this.Title = Title;
            this.Description = Description;
            this.Days = Days;
            this.Price = Price;

        }
        public Tour()
        {  }

    }
}
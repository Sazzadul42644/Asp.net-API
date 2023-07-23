using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APITask.EF.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        public string Name { get; set; }
    }
}
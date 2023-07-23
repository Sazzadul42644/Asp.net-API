using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APITask.EF.Models
{
    public class News
    {
        [Key]
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime date { set; get; }

        [ForeignKey("Category")]
        public int CatID { set; get; }

        public virtual Category Category { set; get; }
    }
}
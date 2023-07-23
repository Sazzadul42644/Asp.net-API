using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using APITask.EF.Models;

namespace APITask.EF
{
    public class APIContext: DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<News> News { set; get; }
    }
}
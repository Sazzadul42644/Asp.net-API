using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APITask.EF;
using APITask.EF.Models;
using System.Data.Entity;

namespace APITask.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/news-category/{Name}")]
        public HttpResponseMessage GetNewsByCategory(string Name)
        {
            var db = new APIContext();
            var category =db .Categories.FirstOrDefault(c => c.Name.ToLower() == Name.ToLower());
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Category not found" });
            }
            var data = db.News.Where(n => n.CatID == category.CatID).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

       
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage GelAll()
        {
            var db = new APIContext();
            var data = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(Category category)
        {
            var db = new APIContext();
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/category/edit")]
        public HttpResponseMessage Update(Category c)
        {
            var db = new APIContext();
            var exp = db.Categories.Find(c.CatID);
            
            try
            {
                db.Entry(exp).CurrentValues.SetValues(c); 
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }
        [HttpDelete]
        [Route("api/category/delete")]
        public HttpResponseMessage Delete(Category c)
        {
            var db = new APIContext();
            var exp = db.Categories.Find(c.CatID);
            try
            {
                db.Categories.Remove(exp);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }     

        }
        [HttpGet]
        [Route("api/category/details")]
        public HttpResponseMessage Details(Category c)
        {
            var db = new APIContext();
            var data = db.Categories.Find(c.CatID);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage All()
        {
            var db = new APIContext();
            var data = db.News.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(News n)
        {
            var db = new APIContext();
            try
            {
                db.News.Add(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/news/edit")]
        public HttpResponseMessage Update(News n)
        {
            var db = new APIContext();
            var exp = db.News.Find(n.Id);

            try
            {
                db.Entry(exp).CurrentValues.SetValues(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpDelete]
        [Route("api/news/delete")]
        public HttpResponseMessage Delete(News n)
        {
            var db = new APIContext();
            var exp = db.News.Find(n.Id);
            try
            {
                db.News.Remove(exp);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/news/{date}")]
        public HttpResponseMessage GetByDate(string date)
        {
            DateTime targetDate;
            if (!DateTime.TryParse(date, out targetDate))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid date format. Use YYYY-MM-DD." });
            }

            try
            {
                var db = new APIContext();

                var data = db.News.Where(n => DbFunctions.TruncateTime(n.date) == targetDate.Date).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



    }
}

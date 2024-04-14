using MvcBlog.DAL;
using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class BlogStatisticController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: BlogStatistic
        public ActionResult Index()
        {
            var query = from b in db.Blogs
                        group b by b.Owner into ownerGroup
                        select new BlogStatistic
                        {
                            Owner = ownerGroup.Key,
                            BlogCount = ownerGroup.Count()
                        };
                        
            return View(query.ToList());
        }

    }
}
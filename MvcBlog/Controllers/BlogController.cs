using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog.DAL;
using MvcBlog.Models;
using PagedList;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Blog
        public ActionResult Index(string searchByName, string searchByDescription, string searchByOwner, string sortOrder, int? page, int? pageSize)
        {
            var blogs = from b in db.Blogs select b;

            if (!String.IsNullOrEmpty(searchByName))
            {
                blogs = blogs.Where(b => b.Name.Contains(searchByName));
            }

            if (!String.IsNullOrEmpty(searchByDescription))
            {
                blogs = blogs.Where(b => b.Description.Contains(searchByDescription));
            }

            if (!String.IsNullOrEmpty(searchByOwner))
            {
                blogs = blogs.Where(b => b.Owner == searchByOwner);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    blogs = blogs.OrderByDescending(b => b.Name);
                    break;
                case "description":
                    blogs = blogs.OrderBy(b => b.Description);
                    break;
                case "description_desc":
                    blogs = blogs.OrderByDescending(b => b.Description);
                    break;
                case "owner":
                    blogs = blogs.OrderBy(b => b.Owner);
                    break;
                case "owner_desc":
                    blogs = blogs.OrderByDescending(b => b.Owner);
                    break;
                default:
                    blogs = blogs.OrderBy(b => b.Name);
                    break;
            }

            int pageNumber = (page ?? 1);
            int size = (pageSize ?? 5);
            return View(blogs.ToPagedList(pageNumber, size));
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Name,Description,Owner,Rank")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Name,Description,Owner,Rank")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

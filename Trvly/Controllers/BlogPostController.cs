using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trvly.Models;

namespace Trvly.Controllers
{
    public class BlogPostController : Controller
    {
        private ApplicationDbContext _context;

        public  BlogPostController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: BlogPost
        [AllowAnonymous]
        public ActionResult IndexPosts()
        {
            List<BlogPost> all = _context.BlogPost.ToList();
            List<BlogPost> Approved = new List<BlogPost>();
            foreach (BlogPost blog in all)
            {
                if (blog.IsApproved)
                {
                    Approved.Add(blog);
                }
            }

            return View(Approved);
        }
        public ActionResult PostBlog() {
            BlogPost blogPost = new BlogPost();

            return View(blogPost);
        }
        
        public ActionResult PostBlogIt(BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                BlogPost b = blogPost;
                return View("PostBlog", b);
            }
            blogPost.IsApproved= false;
           // blogPost.PostedBy =
            _context.BlogPost.Add(blogPost);
            _context.SaveChanges();
            return RedirectToAction("IndexPosts");
        }
             
        public ActionResult UnApprovedPosts() {
            List<BlogPost> all = _context.BlogPost.ToList();
            List<BlogPost> unApproved = new List<BlogPost>();
            foreach(BlogPost blog in all)
            {
                if(!blog.IsApproved) {
                    unApproved.Add(blog);
                }
            }
            return View(unApproved);
        }
        public ActionResult Read(int id)
        {
            var blog = _context.BlogPost.SingleOrDefault(t => t.id == id);
            if (blog == null)
            {

                return HttpNotFound();
            }
            
            return View(blog);
        }
        public ActionResult Read_Only(int id)
        {
            var blog = _context.BlogPost.SingleOrDefault(t => t.id == id);
            if (blog == null)
            {

                return HttpNotFound();
            }

            return View(blog);
        }
        public ActionResult Approve(int id)
        {
            _context.BlogPost.SingleOrDefault(t => t.id == id).IsApproved = true;
            _context.SaveChanges();
           
            return RedirectToAction("UnApprovedPosts");
        }
        public ActionResult Decline()
        {


            return RedirectToAction("UnApprovedPosts");
        }



    }
}
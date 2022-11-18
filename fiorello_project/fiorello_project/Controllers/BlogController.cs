﻿using fiorello_project.DAL;
using fiorello_project.Models;
using fiorello_project.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index(BlogIndexViewModel model)
        {
            var pageCount = await GetPageCountAsync(model.Take);


            if (model.Page <= 0 || model.Page>pageCount ) return NotFound();
          
            var blogs = await PaginateBlogsAsync(model.Page, model.Take);

             model = new BlogIndexViewModel
            {
                Blogs = blogs,
                Page = model.Page,
                PageCount= pageCount,
                Take=model.Take
            };
            return View(model);
        }

        private async Task<List<Blog>> PaginateBlogsAsync(int page,int take)
        {

            return await _appDbContext.Blogs
                 .OrderByDescending(b => b.Id)
                 .Skip((page - 1) * take).Take(take)
                 .ToListAsync();

        }


        private async Task<int> GetPageCountAsync(int take)
        {

            var blogsCount= await _appDbContext.Blogs.CountAsync();

            return (int)Math.Ceiling((decimal)blogsCount / take);

        }



        public async Task<IActionResult> Details(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            var model = new BlogDetailsViewModel
            {
                Title = blog.Title,
                CreateDate = blog.CreateDate,
                Description = blog.Description,
                PhotoName = blog.PhotoName,
            };

            return View(model);
            
        }


    }
}

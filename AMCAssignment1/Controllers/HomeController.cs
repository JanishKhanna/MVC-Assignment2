﻿using AMCAssignment1.Models;
using AMCAssignment1.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMCAssignment1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext DbContext;

        public HomeController()
        {
            DbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Courses()
        {
            var model = DbContext.Courses

            .Select(p => new IndexCoursesViewModel
            {
                CourseId = p.Id,
                Name = p.Name,
                NumberOfHours = p.NumberOfHours,
                Users = p.Users,               
                
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(HomeController.Courses));
            }

            var course = DbContext.Courses.FirstOrDefault(p => p.Id == id);

            if (course == null)
            {
                return RedirectToAction(nameof(HomeController.Courses));
            }

            var model = new IndexCoursesViewModel
            {
                CourseId = course.Id,
                Name = course.Name,
                NumberOfHours = course.NumberOfHours,
                Users = course.Users,
            };
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FluentValidation.ViewModels;

namespace MVC_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpGet]
        public ActionResult AddMovie()
        {
            var viewModel = new AddMovieViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddFluentMovie()
        {
            var viewModel = new AddMovieFluentViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddFluentMovie(AddMovieFluentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
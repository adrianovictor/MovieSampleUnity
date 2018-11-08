using MovieSample.Persistency.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _service;

        public HomeController(IMovieService service)
        {
            _service = service;
        }

        // GET: Home
        public ActionResult Index()
        {
            var movie = _service.GetMovie("teste");

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Complete_App.Models;
using MVC_Complete_App.BizRepositories;
namespace MVC_Complete_App.Controllers
{
    public class SPAController : Controller
    {

        IBizRepository<Category, int> bizRepository;
		public SPAController(IBizRepository<Category, int> bizRepository)
		{
            this.bizRepository = bizRepository;
		}

        // GET: SPA
        public ActionResult Index()
        {
            var cats = bizRepository.GetData();
             
            return View(cats);
        }

        public ActionResult IndexSPA()
        { 
            return View();
        }

        public ActionResult ListCategories()
        {
            return PartialView("ListCategories");
        }


        public ActionResult AddCategory()
        {
            return PartialView("AddCategory");
        }

        public ActionResult EditCategory()
        {
            return PartialView("EditCategory");
        }

        public ActionResult DeleteCategory()
        {
            return PartialView("DeleteCategory");
        }

    }
}
using MVC_Complete_App.BizRepositories;
// import Models and Repository Namespaces
using MVC_Complete_App.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using MVC_Complete_App.CustomFilters;

namespace MVC_Complete_App.Controllers
{

    /// <summary>
    /// Controller class contains Action method.
    /// By default action methods will be executed with Http Get Request
    /// To Execute Action Method for Http Post request
    /// it must be applied with HttpPost attribute
    /// </summary>
    /// 
 //   [RoutePrefix("Categories")]
 // Apply the action filter
  //  [LogFilter]
    public class CategoryController : Controller
    {
        // define an instance of CategoryRespository using the constructor

        IBizRepository<Category, int> catRepository;

        //public CategoryController()
        //{
        //    catRepository = new CategoryBizRepository();
        //}
        /// <summary>
        /// Inject the depednency by seraching 
        /// the Object in the Dependency Container using Interface
        /// </summary>
        public CategoryController(IBizRepository<Category,int> catRepo)
        {
            catRepository = catRepo;
        }



        // GET: Category
        /// <summary>
        /// Return List of Categories
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("List")]
        //[Authorize(Roles ="Admin,Manager,Clerk")]
        public ActionResult Index()
        {
            var result = catRepository.GetData();
            // return View that will display list of Categoeies
            return View(result);
        }

        /// <summary>
        /// The method that will used to respond the view 
        /// for Accepting data for Category
        /// </summary>
        /// <returns></returns>
        /// 
       // [Route("Category/New")]will be access the create
       //Only Authorizer users 

    //    [Authorize(Users = "mahesh@msit.com,tejas@msit.com")]
    // Use roles for Authorization
   // [Authorize(Roles ="Admin,Manager")]
        public ActionResult Create()
        {
            // Checvk if the TempData has some values
            if (TempData.Keys.Count > 0)
            {
                // read the Category key from the TempData
                // and convert (typecast) it into the Category Object
                Category cat = (Category)TempData["Category"];
                // return to the View
                return View(cat);
            }

            var result = new Category();
            // return a view that will show empty 
            // category information
            return View(result);
        }

        /// <summary>
        /// The Create Action method that will be executed
        /// for the Http Post request
        /// 
        /// Exception Handling at Action level using try..catch  block
        /// Mechanism 1 of handling exception
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Category data)
        {
            try
            {
                // Validate the posted model with ModelState property of the Controller base class 
                // This validations will be executed based on Validation rules applied on
                // Model classes using Data Annotations
                if (ModelState.IsValid)
                {
                    // if BasePrice is -Ve then throw exception
                    if (data.BasePrice < 0)
                    {
                        // store data in TempData
                        TempData["Category"] = data;
                        throw new Exception("Price Cannot be -ve");
                    }

                    // then only save the data
                    data = catRepository.Create(data);
                    // Redirect to the Index Action Method
                    return RedirectToAction("Index");
                }
                // if the model is invalid stay on the same veiw and display
                // Validation errors
                return View(data);
            }
            catch (Exception ex)
            {
                // handle the exception and return to Error.cshtml
                // this is a standard error view in Views/Shared folder
                // this view has a Model class as HandleErrorInfo from System.Web.Mvc     
                return View("Error", new HandleErrorInfo(
                        ex,
                        // controller name
                        RouteData.Values["controller"].ToString(),
                        // action name
                        RouteData.Values["action"].ToString()
                    ));
            }
        }


        /// <summary>
        /// This will accept Http Get Request with the 'id'
        /// Parameter in Request URL
        /// and will search record based on id
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult Edit(int id)
        {
            // search record
            var result = catRepository.GetData(id);
            // return view showing the searched record
            return View(result);
        }

        /// <summary>
        /// Accept the Updated values on view
        /// Validate those values and then send to database
        /// The edit method raisean exception for BasePrice less than 0
        /// This exception will be listened by 
        /// OnException method of the controller class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Category data)
        {
            if (ModelState.IsValid)
            {
                if (data.BasePrice < 0)
                    throw new Exception("Base Price Cannot be -ve");
                catRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }

        /// <summary>
        /// Mechanism 2 for handling exception
        /// </summary>
        /// <param name="filterContext"></param>

        protected override void OnException(ExceptionContext filterContext)
        {
            // Handle the excpetion to completye the process
            filterContext.ExceptionHandled = true;
            // read the exception
            Exception ex = filterContext.Exception;
            // set the result property of the ExceptionContrext to the view
            // which you want to show when exception is raised
            // Exception information will be passed to View
            // using ViewDataDictionary
            ViewDataDictionary viewData = new ViewDataDictionary();
            viewData["ControllerName"] = filterContext.RouteData.Values["controller"].ToString();
            viewData["ActionName"] = filterContext.RouteData.Values["action"].ToString();
            ViewData["Exception"] = ex.Message;
            // We cannot pass the Model property for ViewResult
            // because it is read-only
            filterContext.Result = new ViewResult()
            { 
               ViewName = "Error",
               ViewData = viewData
            };
        }


        /// <summary>
        /// Delete record based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var result = catRepository.Delete(id);
            return RedirectToAction("Index");
        }


        public ActionResult ShowProductsForCategory(int id)
        {
            // stoire sdsata in TempData with K/V Pair
            TempData["CategoryRowId"] = id;
          
            return RedirectToAction("Index", "Product");
        }



        /// <summary>
        /// This method will be used for Asynchronous valdiations
        /// to check if the CategoryId already presents n database
        /// Categories table
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public JsonResult CheckIfCategoryIdExist(string CategoryId)
        {


            //if(BasePrice < 0) return Json(false, JsonRequestBehavior.AllowGet);
            //return Json(true, JsonRequestBehavior.AllowGet);

            // check if the collection contsins any result
            var cat = (from c in catRepository.GetData()
                       where c.CategoryId == CategoryId
                       select c).FirstOrDefault();
            if (cat != null)
            {
                // CategoryId is already present
                // generate the response with invalid result
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            // CategoryId is not present
            // generate the response with valid result
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}
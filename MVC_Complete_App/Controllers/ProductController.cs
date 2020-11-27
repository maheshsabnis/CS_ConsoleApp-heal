using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Complete_App.Models;
using MVC_Complete_App.BizRepositories;

namespace MVC_Complete_App.Controllers
{
    /// <summary>
    /// An Exception Filter Applied on controller class
    /// </summary>
    [HandleError(ExceptionType = typeof(Exception), View ="Error")]
    public class ProductController : Controller
    {

        IBizRepository<Product, int> prdRespository;
        IBizRepository<Category, int> catRepository;

        //public ProductController()
        //{
        //    prdRespository = new ProductBizRepository();
        //    catRepository = new CategoryBizRepository();
        //}

        /// <summary>
        /// Injecting the Dependency using Repository Intercace 
        /// </summary>
        public ProductController(IBizRepository<Product, int> prdRespository,
            IBizRepository<Category, int> catRepository)
        {
            this.prdRespository = prdRespository;
            this.catRepository = catRepository;
        }


        // GET: Porduct


        // GET: Product
        /// <summary>
        /// Return List of Categories
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Product> result = new List<Product>();
            // Read data from TempData
            // Check if the TempData has some values 
            if (TempData.Keys.Count > 0)
            {
                // read data from, TempData
                int CatId = Convert.ToInt32(TempData["CategoryRowId"]);
                if (CatId > 0)
                {
                    // filter data based on CategoryRowId
                    result = (from prd in prdRespository.GetData()
                              where prd.CategoryRowId == CatId
                              select prd).ToList();
                    // Keep the data for Keys in TempData
                    TempData.Keep();

                    ViewBag.Message = $"List of Products for Category Row Id {CatId}";
                    if (result.Count == 0)
                    {
                        // there is no Product for the Category Row Id
                        ViewBag.Message = $"There are no Products for Category Row Id {CatId}";
                    }
                  
                }

            }
            else
            {
                // read all products
                result = prdRespository.GetData();
                ViewBag.Message = $"List of All Products";
            }

              
            // return View that will display list of Categoeies
            return View(result);
        }

        /// <summary>
        /// The method that will used to respond the view 
        /// for Accepting data for Product
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            // ViewBag is dynamic object thatb is used to pass additional data from 
            // Action method to View
            ViewBag.Name = "The View For Creating the New Product";
            ViewData["Message"] = "Makes Sure that all values you are passing are valid";

            var result = new Product();
            // List out all Categories and pass it to SelectList object of System.Web.Mvc
            // ViewBag.CategoryRowId, the CategoryRowId key is selected because, it is present into
            // Product class. So when the View is submitted, the CategoryRowId value will also be
            // submitted with Product class.
            //                                     Collection to be passed, Value that will be selected, value taht will be shown on UI     
            ViewBag.CategoryRowId = new SelectList(catRepository.GetData(), "CategoryRowId", "SubCategoryName");
            
            // return a view that will show empty 
            // Product information
            return View(result);
        }

        /// <summary>
        /// The Create Action method that will be executed
        /// for the Http Post request
        /// The exception will be handled by HandleError Filter
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Product data)
        {


            // read the CategoryRowId entered for Product 

            Category cat = new Category();
            cat.CategoryRowId = data.CategoryRowId;
            // retrived the BAsePrice of the Category Based on CategoryRowId
            int basePrice = catRepository.GetData(cat.CategoryRowId).BasePrice;
            if (data.Price < basePrice)
            {
                ViewBag.PriceError = $"Base Price for Category is {basePrice} that is " +
                      $"greated that price" +
                      $" you entered. Please enter value greater than equalto the Price.";
                ViewBag.CategoryRowId = new SelectList(catRepository.GetData(), "CategoryRowId", "SubCategoryName");
                return View(data);
            }

            // Validate the posted model with ModelState property of the Controller base class 
            // This validations will be executed based on Validation rules applied on
            // Model classes using Data Annotations
            if (ModelState.IsValid)
            {
                if (data.Price < 0) throw new Exception("Price Can not be -Ve");
                // then only save the data
                data = prdRespository.Create(data);
                // Redirect to the Index Action Method
                return RedirectToAction("Index");
            }
            // if the model is invalid stay on the same veiw and display
            // Validation errors
            // Make sure that pass the ViewBag / ViewData agian to view
            // otherwise the veiw will crash because the CateryRowId on Creaye View
            // is useing DroDownList to show list og Categories

            // List out all Categories and pass it to SelectList object of System.Web.Mvc
            // ViewBag.CategoryRowId, the CategoryRowId key is selected because, it is present into
            // Product class. So when the View is submitted, the CategoryRowId value will also be
            // submitted with Product class.
            //                                     Collection to be passed, Value that will be selected, value taht will be shown on UI     
            ViewBag.CategoryRowId = new SelectList(catRepository.GetData(), "CategoryRowId", "SubCategoryName");
            return View(data);
        }

        /// <summary>
        /// This will accept Http Get Request with the 'id'
        /// Parameter in Request URL
        /// and will search record based on id
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            // search record
            var result = prdRespository.GetData(id);
            // return view showing the searched record
            return View(result);
        }

        /// <summary>
        /// Accept the Updated values on view
        /// Validate those values and then send to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                prdRespository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }


        /// <summary>
        /// Delete record based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var result = prdRespository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
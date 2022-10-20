using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Product_ivity.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Product_ivity.Controllers {
    public class ProductController : Controller {
        private string baseUrl = "https://gendacproficiencytest.azurewebsites.net/API/";
        public async Task<ActionResult> Index() {
            GridVM<ProductModel> ProductInfo = new GridVM<ProductModel>(); // fix model type
            using (var client = new HttpClient()) {

                //Passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("ProductsAPI/");

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode) {
                    //Storing the response details recieved from web api
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                    // Create view model for page and set properties
                    ProductInfo.Entries = JsonConvert.DeserializeObject<List<ProductModel>>(ProductResponse);
                }
                else {
                    ModelState.AddModelError(string.Empty, "Error retrieving list of products. Please contact support");
                }
                //returning the employee list to view
                return View(ProductInfo);
            }
        }

            // GET: Product/Details/5
            //public ActionResult Details(int id) {
            //    return View();
            //}

            //// GET: Product/Create
            //public ActionResult Create() {
            //    return View();
            //}

            //// POST: Product/Create
            //[HttpPost]
            //public ActionResult Create(FormCollection collection) {
            //    try {
            //        // TODO: Add insert logic here

            //        return RedirectToAction("Index");
            //    }
            //    catch {
            //        return View();
            //    }
            //}

            //// GET: Product/Edit/5
            //public ActionResult Edit(int id) {
            //    return View();
            //}

            //// POST: Product/Edit/5
            //[HttpPost]
            //public ActionResult Edit(int id, FormCollection collection) {
            //    try {
            //        // TODO: Add update logic here

            //        return RedirectToAction("Index");
            //    }
            //    catch {
            //        return View();
            //    }
            //}

            //// GET: Product/Delete/5
            //public ActionResult Delete(int id) {
            //    return View();
            //}

            //// POST: Product/Delete/5
            //[HttpPost]
            //public ActionResult Delete(int id, FormCollection collection) {
            //    try {
            //        // TODO: Add delete logic here

            //        return RedirectToAction("Index");
            //    }
            //    catch {
            //        return View();
            //    }
            //}
        }
    }

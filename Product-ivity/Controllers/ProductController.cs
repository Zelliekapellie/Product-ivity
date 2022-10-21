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
        private string baseUrl = "https://gendacproficiencytest.azurewebsites.net/API/ProductsAPI/";

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<ActionResult> Index() {
            GridVM<ProductModel> ProductInfo = new GridVM<ProductModel>(); // fix model type

           using (var client = new HttpClient()) {

                HttpRequestMessage reqMes = new HttpRequestMessage {
                    RequestUri = new Uri(baseUrl),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage Res = new HttpResponseMessage();
                try {

                    //Sending request to find web api REST service resource 
                     Res = await client.SendAsync(reqMes).ConfigureAwait(false);
                } catch(Exception e) {
                    return View( e.Message);
                }

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
                return View("~/Views/Home/About.cshtml", ProductInfo);
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

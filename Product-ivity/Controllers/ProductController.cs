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
    [RouteArea("Product")]
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

        // POST: Product/Create
        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Create(string pname, string pcategory, string price) {
            string returnMessage = "";
            try {
                using (var client = new HttpClient()) {

                    HttpRequestMessage reqMes = new HttpRequestMessage {
                        RequestUri = new Uri(baseUrl),
                        Method = HttpMethod.Post
                    };
                    HttpResponseMessage Res = new HttpResponseMessage();
                    try {

                        //Sending request to find web api REST service resource 
                        Res = await client.SendAsync(reqMes).ConfigureAwait(false);
                    }
                    catch (Exception e) {
                        returnMessage = e.Message;
                    }

                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode) {
                        returnMessage = "OK";
                    }
                    else {
                        returnMessage = "Error creating product. Please contact support";
                    }
                }

                return returnMessage;
            }
            catch {
                return "Error creating product. Please contact support";
            }
        }

        

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

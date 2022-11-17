using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppCarsCrud.Models;

namespace WebAppCarsCrud.Controllers
{
    public class CarsMvcController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Cars> carsList = new List<Cars>();
            client.BaseAddress = new Uri("https://localhost:44399/api/CarsApi");
            var response = client.GetAsync("CarsApi");
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) {
                var display = test.Content.ReadAsAsync<List<Cars>>();
                display.Wait();
                carsList = display.Result;

            }

            return View(carsList);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cars c) {

            client.BaseAddress = new Uri("https://localhost:44399/api/CarsApi");
            var response = client.PostAsJsonAsync<Cars>("CarsApi",c);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAppCarsCrud.Models;

namespace WebAppCarsCrud.Controllers
{
    public class CarsApiController : ApiController
    {
        CarsEntities db = new CarsEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCars() 
        {
            List<Cars> list = db.Cars.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CarInsert(Cars c)
        {
            db.Cars.Add(c);
            db.SaveChanges();
            return Ok();
        }
    }
}

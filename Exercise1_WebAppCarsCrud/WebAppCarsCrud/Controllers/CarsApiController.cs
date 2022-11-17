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

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCarsById(int id)
        {
            var c = db.Cars.Where(model => model.Id == id).FirstOrDefault();
            return Ok(c);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CarInsert(Cars c)
        {
            db.Cars.Add(c);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult CarUpdate(Cars c)
        {
            var car = db.Cars.Where(model => model.Id == c.Id).FirstOrDefault();
            if (car != null) {
                car.Id = c.Id;
                car.Make = c.Make;
                car.Model = c.Model;
                car.Year = c.Year;
                car.Doors = c.Doors;
                car.Color = c.Color;
                car.Price = c.Price;
                db.SaveChanges();
            } else
            {
                return NotFound();
            }

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult CarDelete(int id)
        {
            var car = db.Cars.Where(model => model.Id == id).FirstOrDefault();
            db.Entry(car).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}

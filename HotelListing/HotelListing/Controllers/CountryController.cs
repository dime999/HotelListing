using HotelListing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContextcs context;
        public CountryController(AppDbContextcs context)
        {
            this.context = context;
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id < 0)
                return BadRequest("Pogresan ID");

            Country country = context.Countries.FirstOrDefault(c => c.Id == id);

            if(country==null)
            {
                return BadRequest("Pogresan ID");
            }

            return Ok(country);
        }

        [HttpGet]
        public ActionResult<List<Country>>GetAll()
        {
            var data = context.Countries.OrderByDescending(s => s.Id).AsQueryable();

            return data.Take(100).ToList();
        }


        [HttpPost]
        public ActionResult<Country> Post(CountryCreateModelcs x)
        {
            Country country = new Country { Name = x.Name, ShortName = x.ShortName };
            context.Add(country);
            context.SaveChanges();
            return country;
        }

        [HttpPut]
        public ActionResult<Country> Put(int id,CountryCreateModelcs x)
        {
            Country country = context.Countries.FirstOrDefault(c => c.Id == id);

            if(country==null)
            {
                return BadRequest("Pogresan ID");
            }

            country.Name = x.Name;
            country.ShortName = x.ShortName;
            context.SaveChanges();
            return country;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Country country = context.Countries.FirstOrDefault(c => c.Id == id);

            if(country==null)
            {
                return BadRequest("Pogresa ID");
            }
            context.Remove(country);
            context.SaveChanges();
            return NoContent();

        }

        
    }
}

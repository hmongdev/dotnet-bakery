using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        // _context is an instance of our ApplicationContext class
        // We use _context to query our database
        // Think of it kind of like `pool.query` from node-pg
        private readonly ApplicationContext _context;

        // This is out constructor function
        // Our `ApplicationContext` is automagically passed to it 
        // as an argument by .NET
        public BakersController(ApplicationContext context) 
        {
            _context = context;
        }
        
        // The `[HttpGet]` attribute defines this method as our `GET /api/bakers` endpoint
        // This function returns a `IEnumerable<Baker>` object,
        // which is .NET's fancy way of saying "A list of baker objects"

        //GET all
        [HttpGet]
        public IEnumerable<Baker> GetAll()
        {
            // Look ma, no SQL queries!
            return _context.Bakers;
        }

        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id) {
            Baker baker =  _context.Bakers
                .SingleOrDefault(baker => baker.id == id);
            
            // Return a `404 Not Found` if the baker doesn't exist
            if(baker is null) {
                return NotFound();
            }
            return baker;
        }

        // POST /api/bakers
        // Note that .NET parses our JSON request body for us
        // and converts it to a `Baker` model object.
        [HttpPost]
        public Baker Post(Baker baker) 
        {
            //add a baker
            _context.Add(baker);
            //save changes
            _context.SaveChanges();
            //return Baker
            return baker;
        }
    }
}
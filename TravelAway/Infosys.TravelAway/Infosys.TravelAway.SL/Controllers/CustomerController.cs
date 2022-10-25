﻿using Infosys.TravelAway.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infosys.TravelAway.SL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerRepository customerRepo;

        public CustomerController()
        {
            customerRepo = new CustomerRepository();
        }
        

        [HttpGet]
        public JsonResult GetAllCustomers()
        {
            List<DAL.Models.Customers> customers;
            try
            {
                customers = customerRepo.GetAllCustomers();
            }
            catch (Exception)
            {
                customers = null;
            }
            return Json(customers);
        }

        
        [HttpGet]
        public JsonResult GetAllPackageCategories()
        {
            List<DAL.Models.PackageCategories> packageCategories;
            try
            {
                packageCategories = customerRepo.GetAllPackageCategories()
            }
            catch (Exception)
            {
                packageCategories = null;
            }
            return Json(packageCategories);
        }
        
        
        [HttpGet]
        public JsonResult GetAllPackages()
        {
            List<DAL.Models.Packages> packages;
            try
            {
                packages = customerRepo.GetAllPackages()
            }
            catch (Exception)
            {
                packages = null;
            }
            return Json(packages);
        }


        [HttpGet]
        public JsonResult GetAllPackageDetails()
        {
            List<DAL.Models.PackageDetails> packageDetails;
            try
            {
                packageDetails = customerRepo.GetAllPackageDetails()
            }
            catch (Exception)
            {
                packageDetails = null;
            }
            return Json(packageDetails);
        }







        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

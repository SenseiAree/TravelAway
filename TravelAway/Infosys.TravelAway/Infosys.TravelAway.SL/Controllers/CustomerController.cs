using Infosys.TravelAway.DAL;
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
        private readonly TravelAwayRepository customerRepo;

        public CustomerController()
        {
            customerRepo = new TravelAwayRepository();
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
                packageCategories = customerRepo.GetAllPackageCategories();
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
                packages = customerRepo.GetAllPackages();
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
                packageDetails = customerRepo.GetAllPackageDetails();
            }
            catch (Exception)
            {
                packageDetails = null;
            }
            return Json(packageDetails);
        }
        
        
        [HttpPost]
        public JsonResult RegisterCustomer(DAL.Models.Customers customer)
        {           
            int passCase;
            try
            {
                passCase = customerRepo.RegisterCustomer(customer);
                
            }
            catch (Exception)
            {
                passCase = 0;
            }
            return Json(passCase);
        }



    }
}

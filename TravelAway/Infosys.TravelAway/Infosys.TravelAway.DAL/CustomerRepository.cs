using Infosys.TravelAway.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infosys.TravelAway.DAL
{
    public class CustomerRepository
    {
        private readonly TravelAwayDBContext _dBContext;
        public CustomerRepository()
        {
            this._dBContext = new TravelAwayDBContext();
        }

        #region GetAllCustomers
        public List<Customers> GetAllCustomers()
        {
            List<Customers> customers;
            try
            {
                customers = this._dBContext.Customers.ToList();
            }
            catch (Exception)
            {
                customers = null;
            }
            return customers;
        }

        #endregion

        #region GetAllPackageCategories
        public List<PackageCategories> GetAllPackageCategories()
        {
            List<PackageCategories> packageCategories;
            try
            {
                packageCategories = this._dBContext.PackageCategories.ToList();
            }
            catch (Exception)
            {
                packageCategories = null;
            }
            return packageCategories;
        }

        #endregion

        #region GetAllPackages
        public List<Packages> GetAllPackages()
        {
            List<Packages> packages;
            try
            {
                packages = this._dBContext.Packages.ToList();
            }
            catch (Exception)
            {
                packages = null;
            }
            return packages;
        }

        #endregion

        #region GetAllPackageDetails

        public List<PackageDetails> GetAllPackageDetails()
        {
            List<PackageDetails> packageDetails;
            try
            {
                packageDetails = this._dBContext.PackageDetails.ToList();
            }
            catch (Exception)
            {
                packageDetails = null;
            }
            return packageDetails;
        }

        #endregion
    }
}

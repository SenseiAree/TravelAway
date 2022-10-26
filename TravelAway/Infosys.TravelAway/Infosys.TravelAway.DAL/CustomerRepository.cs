using Infosys.TravelAway.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        //select @username, @password from database where username = 'Areetra' --' and password = @password

        #region RegisterCustomer

        public int RegisterCustomer(Customers customers)
        {
            SqlParameter prmFirstName = new SqlParameter("@FirstName", customers.FirstName);
            SqlParameter prmLastName = new SqlParameter("@LastName", customers.LastName);
            SqlParameter prmEmailId = new SqlParameter("@EmailId", customers.EmailId);
            SqlParameter prmPassword = new SqlParameter("@Password", customers.Password);
            SqlParameter prmGender = new SqlParameter("@Gender", customers.Gender);
            SqlParameter prmContactNumber = new SqlParameter("@ContactNumber", customers.ContactNumber);
            SqlParameter prmDateOfBirth = new SqlParameter("@DateOfBirth", customers.DateOfBirth);
            SqlParameter prmAddress = new SqlParameter("@Address", customers.Address);

            SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            int returnVal;
            try
            {
                int temp = this._dBContext.Database.ExecuteSqlRaw(
                    "EXEC @ReturnValue = usp_RegisterCustomer @FirstName, @LastName, @EmailId, @Password, @Gender, @ContactNumber, @DateOfBirth, @Address"
                    , prmReturnValue, prmFirstName, prmLastName, prmEmailId, prmPassword
                    , prmGender, prmContactNumber, prmDateOfBirth, prmAddress);
                returnVal = Convert.ToInt32(prmReturnValue.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.ToString());
                returnVal = -99;
            }

            return returnVal;
        }

        #endregion

        #region UpdateCustomer

        public bool UpdateCustomer(Customers customer)
        {
            bool returnCase = false;
            try
            {
                Customers customerTobeUpdated = this._dBContext.Customers.Find(customer.CustomerId);
                if (customerTobeUpdated != null)
                {
                    customerTobeUpdated.FirstName = customer.FirstName;
                    customerTobeUpdated.LastName = customer.LastName;
                    customerTobeUpdated.EmailId = customer.EmailId;
                    customerTobeUpdated.Password = customer.Password;
                    customerTobeUpdated.Gender = customer.Gender;
                    customerTobeUpdated.ContactNumber = customer.ContactNumber;
                    customerTobeUpdated.DateOfBirth = customer.DateOfBirth;
                    customerTobeUpdated.Address = customer.Address;


                    this._dBContext.Customers.Update(customerTobeUpdated);
                    int SaveChanges = this._dBContext.SaveChanges();
                    returnCase = SaveChanges == 1;
                }
            }
            catch (Exception)
            {

                returnCase = false;
            }
            return returnCase;
        }

        #endregion

    }


}

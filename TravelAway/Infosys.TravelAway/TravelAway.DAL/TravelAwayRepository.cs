using TravelAway.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace TravelAway.DAL
{
    public class TravelAwayRepository
    {
        private readonly TravelAwayDBContext _dBContext;
        public TravelAwayRepository()
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

        public void LoginCustomer(string emailId, object password)
        {
            throw new NotImplementedException();
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

        #region LoginCustomer

        public Customers LoginCustomer(string emailId, string password)
        {
            SqlParameter prmEmailId = new SqlParameter("@EmailId", emailId);
            SqlParameter prmPassword = new SqlParameter("@Password", password);

            SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

            Customers returningCustomer = null;
            try
            {
                int temp = _dBContext.Database.ExecuteSqlRaw("EXEC @ReturnValue = [usp_Login] @EmailId, @Password", prmReturnValue, prmEmailId, prmPassword);
                if (Convert.ToInt32(prmReturnValue.Value) == 1)
                {
                    returningCustomer = _dBContext.Customers.Where(a => a.EmailId == emailId).Select(a => new Customers()
                    {
                        CustomerId = a.CustomerId,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        EmailId = a.EmailId,
                        Gender = a.Gender,
                        ContactNumber = a.ContactNumber,
                        DateOfBirth = a.DateOfBirth,
                        Address = a.Address,
                        PackageDetails = a.PackageDetails,
                        PackageDetailsId = a.PackageDetailsId,
                        SysDateOfJoining = a.SysDateOfJoining,
                        SysLastLogin = a.SysLastLogin,
                        SysLogoutTime = a.SysLogoutTime
                    }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                returningCustomer = null;
            }
            return returningCustomer;
        }

        #endregion

        #region LogoutCustomer

        public bool LogoutCustomer(string customerId)
        {
            bool status = false;
            try
            {
                Customers customers = _dBContext.Customers.Find(customerId);
                if (customers != null)
                {
                    SqlParameter prmCustomerId = new SqlParameter("@CustomerId", customers.CustomerId);

                    SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

                    int temp = _dBContext.Database.ExecuteSqlRaw("EXEC @ReturnValue = [usp_Logout] @CustomerId", prmReturnValue, prmCustomerId);
                    status = Convert.ToInt32(prmReturnValue.Value) == 1;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion


        //For Self Analysis, if needed.
        #region DeleteCustomer
        public bool DeleteCustomer(string CustomerId)
        {
            bool status = false;
            try
            {
                Customers temp = _dBContext.Customers.Find(CustomerId);
                if (temp != null)
                {
                    this._dBContext.Remove(temp);
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        #endregion
    }


}

﻿using TravelAway.DAL;
using TravelAway.DAL.Models;
using System;

namespace TravelAway.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Draw("TestGetAllPackageCategories");
            //Draw("TestGetAllPackages");
            //Draw("TestGetAllPackageDetails");
            Draw("TestGetAllCustomers");
            Draw("TestRegisterCustomer");
            Draw("TestGetAllCustomers");
            Draw("TestUpdateCustomer");
            Draw("TestGetAllCustomers");
        }


        #region TestGetAllCustomers

        public static void TestGetAllCustomers()
        {
            TravelAwayRepository customerRepository = new TravelAwayRepository();
            Console.WriteLine(@"{0,-20}{1,-20}{2,-20}{3,-30}{4,-20}", "Customer ID", "FirstName", "LastName", "Email ID","Address");
            try
            {
                foreach (Customers eachCustomer in customerRepository.GetAllCustomers())
                {
                    Console.WriteLine(@"{0,-20}{1,-20}{2,-20}{3,-30}{4,-20}", eachCustomer.CustomerId, eachCustomer.FirstName, eachCustomer.LastName, eachCustomer.EmailId, eachCustomer.Address);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error in Finding Customers");
            }

        }

        #endregion
        #region TestGetAllPackageCategories
        public static void TestGetAllPackageCategories()
        {
            TravelAwayRepository customerRepository = new TravelAwayRepository();
            Console.WriteLine(@"{0,-20}{1,-20}", "Category ID", "Category Name");
            try
            {
                foreach (PackageCategories eachPackageCategory in customerRepository.GetAllPackageCategories())
                {
                    Console.WriteLine(@"{0,-20}{1,-20}", eachPackageCategory.CategoryId, eachPackageCategory.CategoryName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Finding PackageCategories");
            }


        }

        #endregion
        #region TestGetAllPackages

        public static void TestGetAllPackages()
        {
            TravelAwayRepository customerRepository = new TravelAwayRepository();
            Console.WriteLine(@"{0,-20}{1,-20}{2,-20}", "Package ID", "Package Name", "Type of Package");
            try
            {
                foreach (Packages eachPackage in customerRepository.GetAllPackages())
                {
                    Console.WriteLine(@"{0,-20}{1,-20}{2,-20}", eachPackage.PackageId, eachPackage.PackageName, eachPackage.TypeOfPackage);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Finding Packages");
            }
        }

        #endregion

        #region TestGetAllPackageDetails

        public static void TestGetAllPackageDetails()
        {
            TravelAwayRepository customerRepository = new TravelAwayRepository();

            foreach (PackageDetails eachPackageDetail in customerRepository.GetAllPackageDetails())
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("{0,-20}{1,-20}", "PackageDetails ID:", eachPackageDetail.PackageDetailsId);
                Console.WriteLine("{0,-20}{1,-20}", "Places to visit:", eachPackageDetail.PlacesToVisit);
                Console.WriteLine("{0,-20}{1,-20}", "Details:", eachPackageDetail.PackageDescription);
                Console.WriteLine("{0,-20}{1,-20}", "Price:", eachPackageDetail.Price);
                Console.WriteLine("{0,-20}{1,-20}", "Days/Night:", eachPackageDetail.DaysAndNight);
                Console.WriteLine("{0,-20}{1,-20}", "Accomodation Availablility:", eachPackageDetail.Accommodation);
                Console.WriteLine("*******************************************");
            }
        }

        #endregion
        #region TestRegisterCustomer
        public static void TestRegisterCustomer()
        {
            Customers customers = new Customers()
            {
                FirstName = "Rebecca",
                LastName = "Matthew",
                ContactNumber = "1234567890",
                Address = "Indonesia",
                EmailId = "rebecca.mathew@gmail.com",
                Gender = "F",
                Password = "rebeccaMatthew",
                DateOfBirth = new DateTime(2000, 05, 25)
            };
            TravelAwayRepository customerRepository = new TravelAwayRepository();
            int returnValue = customerRepository.RegisterCustomer(customers);
            switch (returnValue)
            {
                case 1:
                    Console.WriteLine("Successfully Added");
                    break;
                case -1:
                    Console.WriteLine("FirstName format is not matched");
                    break;
                case -2:
                    Console.WriteLine("LastName format is not matched");
                    break;
                case -3:
                    Console.WriteLine("Email format is not matched");
                    break;
                case -4:
                    Console.WriteLine("Password format is not matched");
                    break;
                case -5:
                    Console.WriteLine("ContactNumber format is not matched");
                    break;
                case -6:
                    Console.WriteLine("Date format is not matched");
                    break;
                case -7:
                    Console.WriteLine("Email already exists");
                    break;
                case -99:
                    Console.WriteLine("Error Found in Stored Procedure");
                    break;


                default:
                    Console.WriteLine("Some error occurred.");
                    break;
            }

        }
        #endregion
        #region TestUpdateCustomer
        public static void TestUpdateCustomer()
        {
            Customers customers = new Customers()
            {
                CustomerId = "C1004",
                FirstName = "Rebecca",
                LastName = "Matthew",
                ContactNumber = "1234567890",
                Address = "Infosys, Pune",
                EmailId = "rebecca.mathew@gmail.com",
                Gender = "F",
                Password = "rebeccaMatthew",
                DateOfBirth = new DateTime(2000, 05, 25)
            };
            TravelAwayRepository customerRepository = new TravelAwayRepository();
            bool testCase;
            try
            {

                testCase = customerRepository.UpdateCustomer(customers);
                if (testCase)
                {
                    Console.WriteLine("Address of Rebecca Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Updation Failed");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some error occured in TestUpdateFunction");
            }
        }

        #endregion

        public static void Draw(string functionName)
        {
            Console.WriteLine("==================================================================================================");
            switch (functionName)
            {
                case "TestGetAllCustomers":
                    TestGetAllCustomers();
                    break;
                case "TestGetAllPackageCategories":
                    TestGetAllPackageCategories();
                    break;
                case "TestGetAllPackages":
                    TestGetAllPackages();
                    break;
                case "TestGetAllPackageDetails":
                    TestGetAllPackageDetails();
                    break;
                case "TestRegisterCustomer":
                    TestRegisterCustomer();
                    break;
                case "TestUpdateCustomer":
                    TestUpdateCustomer();
                    break;
                default:
                    Console.WriteLine("Invalid Function Name selected");
                    break;
            }
            Console.WriteLine("==================================================================================================");
            Console.WriteLine();
        }


    }
}

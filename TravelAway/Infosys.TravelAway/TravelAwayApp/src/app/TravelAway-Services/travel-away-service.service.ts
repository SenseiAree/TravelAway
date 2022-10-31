import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Customer } from '../TravelAway-Interfaces/Customer';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { PackageCategories } from '../TravelAway-Interfaces/package-categories';
import { Packages } from '../TravelAway-Interfaces/packages';
import { PackageDetails } from '../TravelAway-Interfaces/package-details';
import { LoginTemplate } from '../TravelAway-Interfaces/login-template';

@Injectable({
  providedIn: 'root'
})

export class TravelAwayServiceService{

  constructor(private http: HttpClient) { }
  private readonly URL: string = "https://localhost:44377/api/Customer/"

  RegisterCustomer(customer: Customer): Observable<number> {    
    return this.http.post<number>(this.URL+"RegisterCustomer", customer).pipe(catchError(this.errorHandler));
  }
  UpdateCustomerDetails(customer: Customer): Observable<boolean> {
    return this.http.put<boolean>(this.URL+"UpdateCustomer", customer).pipe(catchError(this.errorHandler));
  }
  LoginCustomer(customer: LoginTemplate): Observable<Customer> {
    return this.http.post<Customer>(this.URL + "LoginCustomer", customer).pipe(catchError(this.errorHandler));
  }
  LogoutCustomer(customer: { customerId: string }): Observable<boolean> {
    return this.http.post<boolean>(this.URL + "LogoutCustomer", customer).pipe(catchError(this.errorHandler));
  }
  GetAllPackageCategories(): Observable<PackageCategories[]> {
    return this.http.get<PackageCategories[]>(this.URL + "GetAllPackageCategories").pipe(catchError(this.errorHandler));
  }
  GetAllPackages(): Observable<Packages[]> {
    return this.http.get<Packages[]>(this.URL + "GetAllPackages").pipe(catchError(this.errorHandler));
  }
  GetAllPackageDetails(): Observable<PackageDetails[]> {
    return this.http.get<PackageDetails[]>(this.URL + "GetAllPackageDetails").pipe(catchError(this.errorHandler));
  }
  GetAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.URL + "GetAllCustomers").pipe(catchError(this.errorHandler));
  }






  private errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }


}

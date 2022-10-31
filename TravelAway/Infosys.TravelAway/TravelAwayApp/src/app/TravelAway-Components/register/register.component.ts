import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'protractor';
import { Customer } from '../../TravelAway-Interfaces/Customer';
import { TravelAwayServiceService } from '../../TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  returnData: number;
    errorMsg: HttpErrorResponse;
    nestResponse: Customer;
  
  constructor(private _tAService: TravelAwayServiceService, private router: Router) { }
  signupSuccess: boolean = false;
  ngOnInit(): void {
  }
  RegisterCustomer(signupForm: NgForm) {
    let customer: Customer = {
      customerId: null,
      firstName: signupForm.value.firstName,
      lastName: signupForm.value.lastName,
      emailId: signupForm.value.emailId,
      password: signupForm.value.password,
      address: signupForm.value.address,
      dateOfBirth: signupForm.value.dateOfBirth.toString(),
      contactNumber: signupForm.value.contactNumber,
      gender: signupForm.value.gender,
      packageDetails: null,
      packageDetailsId: null,
      sysDateOfJoining: null,
      sysLastLogin: null,
      sysLogoutTime: null
    }
    this._tAService.RegisterCustomer(customer).subscribe(
      (responseData) => {
        this.returnData = responseData;
        console.log(this.returnData);
        if (this.returnData == 1) {
          this.signupSuccess = true;
        }
      },
      (responseError) => { this.errorMsg = responseError; console.log(this.errorMsg); }
    );
  }
  
}

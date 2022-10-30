import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../TravelAway-Interfaces/Customer';
import { LoginTemplate } from '../../TravelAway-Interfaces/login-template';
import { LoginToHomeInteractionService } from '../../TravelAway-Services/login-to-home-interaction.service';
import { TravelAwayServiceService } from '../../TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  data: Customer;
  errorMsg: HttpErrorResponse;

  constructor(private _tAService: TravelAwayServiceService, private router: Router, private _logHomeInteract: LoginToHomeInteractionService) { }

  ngOnInit(): void {
  }
  showInvalidEmailIdOrPasswordDiv: boolean = false;

  submitLoginForm(loginForm: NgForm) {
    let email: string = loginForm.value.email;
    let password: string = loginForm.value.password;
    let loginTemplate: LoginTemplate = { emailId: email, password: password };
    this._tAService.LoginCustomer(loginTemplate).subscribe(
      (responseData) => {
        this.data = responseData;
        if (this.data != null) {
          sessionStorage.setItem("CustomerId", this.data.customerId);
          sessionStorage.setItem("FirstName", this.data.firstName);
          sessionStorage.setItem("LastName", this.data.lastName);
          sessionStorage.setItem("Gender", this.data.gender);
          sessionStorage.setItem("Address", this.data.address);
          sessionStorage.setItem("ContactNumber", this.data.contactNumber);
          sessionStorage.setItem("DateOfBirth", this.data.dateOfBirth);
          sessionStorage.setItem("PackageDetails", this.data.packageDetails);
          sessionStorage.setItem("PackageDetailsId", this.data.packageDetailsId);
          sessionStorage.setItem("SysDateOfJoining", this.data.sysDateOfJoining);
          sessionStorage.setItem("SysLastLogin", this.data.sysLastLogin);
          sessionStorage.setItem("SysLogoutTime", this.data.sysLogoutTime);
          this._logHomeInteract.EmitFunction(true);
          this.showInvalidEmailIdOrPasswordDiv = false;
          this.router.navigate(['home']);
        } else {
          sessionStorage.clear();
          this.showInvalidEmailIdOrPasswordDiv = true;
        }
      },
      (responseError) => { this.errorMsg = responseError; console.log(this.errorMsg); sessionStorage.clear(); }
    );
  }
}

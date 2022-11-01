import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from '../../TravelAway-Interfaces/Customer';
import { TravelAwayServiceService } from '../../TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {
  temp: string;
  male: { gender: string, URL: string } = { gender: "M", URL: "https://cdn-icons-png.flaticon.com/512/4139/4139981.png" };
  female: { gender: string, URL: string } = { gender: "F", URL: "https://cdn-icons-png.flaticon.com/512/4323/4323004.png" };
    errorMsg: HttpErrorResponse;
    response: boolean;

  constructor(private _tAService: TravelAwayServiceService) { }
  customerProfile: Customer;
  ngOnInit(): void {
    this.customerProfile = {
      customerId: sessionStorage.getItem('CustomerId'),
      firstName: sessionStorage.getItem('FirstName'),
      lastName: sessionStorage.getItem('LastName'),
      gender: sessionStorage.getItem('Gender'),
      address: sessionStorage.getItem('Address'),
      contactNumber: sessionStorage.getItem('ContactNumber'),
      dateOfBirth: sessionStorage.getItem('DateOfBirth').substring(0,10),
      emailId: sessionStorage.getItem('EmailId'),
      password: sessionStorage.getItem('Password'),
      packageDetailsId: sessionStorage.getItem('PackageDetailsId'),
      sysDateOfJoining: sessionStorage.getItem('SysDateOfJoining'),
      sysLastLogin: sessionStorage.getItem('SysLastLogin'),
      sysLogoutTime: sessionStorage.getItem('SysLogoutTime'),
      packageDetails: sessionStorage.getItem('PackageDetails')    
      
    };
  }
  updateInProgress: boolean = false;
  EnterUpdationMode(cardbox: HTMLDivElement) {
    this.temp = cardbox.style.boxShadow;
    cardbox.style.boxShadow = "0px 0px 100px 0px #dc3545";
    this.updateInProgress = true;
  }
  UpdateUpdationMode(cardbox: HTMLDivElement) {
    let div: any = cardbox.getElementsByClassName('inputborderless');
    let firstName: string = div[0].value;
    let lastName: string = div[1].value;
    let emailId: string = div[2].value;
    let contactNumber: string = div[3].value;
    let dateOfBirth: string = div[4].value;
    let gender: string = div[5].value;
    let address: string = div[6].value;
    let password: string = div[7].value;
    for (var i = 0; i < div.length; i++) {
      console.log(div[i].value);
    }
    let packageDetails: string = null;
    let packageDetailsId: string = null;
    if (sessionStorage.getItem('PackageDetails') != null) {
      packageDetails = sessionStorage.getItem('PackageDetails');
    }
    if (sessionStorage.getItem('PackageDetailsId') != null) {
      packageDetailsId = sessionStorage.getItem('PackageDetailsId');
    }

    this.customerProfile = {
      customerId: sessionStorage.getItem('CustomerId'),
      firstName: firstName,
      lastName: lastName,
      gender: gender,
      address: address,
      contactNumber: contactNumber,
      dateOfBirth: dateOfBirth,
      emailId: emailId,
      password: password,
      packageDetailsId: null,
      sysDateOfJoining: sessionStorage.getItem('SysDateOfJoining').substring(0,10),
      sysLastLogin: sessionStorage.getItem('SysLastLogin').substring(0, 10),
      sysLogoutTime: sessionStorage.getItem('SysLogoutTime').substring(0, 10),
      packageDetails: null
    };
    console.log(this.customerProfile);

    this._tAService.UpdateCustomerDetails(this.customerProfile).subscribe(
      (responseData) => {
        this.response = responseData;
        if (this.response) {
          console.log("Updation Successful");
        } else {
          console.log("Updation Failed. Try Again sometime later.");
        }
      },
      (responseError) => {
        this.errorMsg = responseError; console.log(this.errorMsg);
        console.log("ResponseError is found. The error is shown below");
        console.log(this.errorMsg);
      },
      () => { }
    );

    cardbox.style.boxShadow = this.temp;
    this.updateInProgress = false;
  }
  ExitUpdationMode(cardbox: HTMLDivElement) {
    cardbox.style.boxShadow = this.temp;
    this.updateInProgress = false;
  }
}

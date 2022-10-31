import { Component, OnInit } from '@angular/core';
import { Customer } from '../../TravelAway-Interfaces/Customer';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {
  temp: string;
  male: { gender: string, URL: string } = { gender: "M", URL: "https://cdn-icons-png.flaticon.com/512/4139/4139981.png" };
  female: { gender: string, URL: string } = { gender: "F", URL: "https://cdn-icons-png.flaticon.com/512/4323/4323004.png" };

  constructor() { }
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
    cardbox.style.boxShadow = this.temp;
    this.updateInProgress = false;
  }
  ExitUpdationMode(cardbox: HTMLDivElement) {
    cardbox.style.boxShadow = this.temp;
    this.updateInProgress = false;
  }
}

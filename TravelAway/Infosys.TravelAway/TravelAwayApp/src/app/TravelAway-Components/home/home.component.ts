import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Packages } from '../../TravelAway-Interfaces/packages';
import { TravelAwayServiceService } from '../../TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  errorMsg: HttpErrorResponse;
  Packages: Packages[];

  constructor( private _packageService: TravelAwayServiceService) { }
  


  ngOnInit(): void {
    this.getPackages();
  }

  getPackages() {
    this._packageService.GetAllPackages().subscribe(
      (responseData) => { this.Packages = responseData; },
      (responseError) => { this.errorMsg = responseError; }
    );
  }

}

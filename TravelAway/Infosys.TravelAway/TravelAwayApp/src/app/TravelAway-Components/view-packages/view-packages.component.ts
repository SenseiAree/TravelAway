import { HttpErrorResponse } from '@angular/common/http';
import { AfterContentInit } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { AfterViewChecked } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { PackageCategories } from '../../TravelAway-Interfaces/package-categories';
import { Packages } from '../../TravelAway-Interfaces/packages';
import { TravelAwayServiceService } from '../../TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-view-packages',
  templateUrl: './view-packages.component.html',
  styleUrls: ['./view-packages.component.css']
})
export class ViewPackagesComponent implements OnInit {
  errorMsgDivForPackageCategories: HttpErrorResponse;
  errorMsgDivForPackages: HttpErrorResponse;
  PackageCategories: PackageCategories[];
  Packages: Packages[];
  filteredPackages: Packages[];
  constructor(private _getPackageService: TravelAwayServiceService, private router: Router) { }    

  categorySelection: string = "All";
  ngOnInit(): void {
    this.categorySelection = "All";
    this.getPackageCategories();
    this.getPackages();
    this.filteredPackages = this.Packages;
  }
  RouteToLoginOrViewPackages() {
    if (sessionStorage.getItem("CustomerId") == null) {
      this.router.navigate(['login']);
    } else {
      this.router.navigate(['404Error']);
    }
  }

  CategorySelected() {
    console.log(this.categorySelection);
    console.log(this.Packages);
    console.log(this.filteredPackages);
    if (this.categorySelection == "All") {
      this.filteredPackages = this.Packages;
    } else {
      this.filteredPackages = this.Packages.filter(
        responsePackage => responsePackage.categoryId == this.categorySelection 
      );
    }
  }
  getPackages() {
    this._getPackageService.GetAllPackages().subscribe(
      (responseData) => { this.Packages = responseData; this.filteredPackages = responseData; },
      (responseError) => {
        this.errorMsgDivForPackages = responseError;
        console.log(this.errorMsgDivForPackages);
      }
    );
  }
  getPackageCategories() {
    this._getPackageService.GetAllPackageCategories().subscribe(
      (responseData) => { this.PackageCategories = responseData; },
      (responseError) => {
        this.errorMsgDivForPackageCategories = responseError;
        console.log(this.errorMsgDivForPackageCategories);
      }
    );
  }

}

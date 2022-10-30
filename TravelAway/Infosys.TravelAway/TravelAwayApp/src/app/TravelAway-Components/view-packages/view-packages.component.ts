import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
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
  constructor(private _getPackageService: TravelAwayServiceService) { }

  ngOnInit(): void {
    this.getPackageCategories();
    this.getPackages();
    this.filteredPackages = this.Packages;
  }
  categorySelection: string = "All";

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
    console.log(this.filteredPackages);
  }
  getPackages() {
    this._getPackageService.GetAllPackages().subscribe(
      (responseData) => { this.Packages = responseData; },
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

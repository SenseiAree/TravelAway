import { AfterContentChecked, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IButtonLink } from './TravelAway-Interfaces/ibutton-link';
import { LoginToHomeInteractionService } from './TravelAway-Services/login-to-home-interaction.service';
import { TravelAwayServiceService } from './TravelAway-Services/travel-away-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterContentChecked {
  title = 'TravelAway';
  firstName: string = sessionStorage.getItem('FirstName');
  buttonNameAndLinks: IButtonLink[] = [
    { buttonName: "Log In", routerLink: "/login", buttonClass: "fa-user" },
    { buttonName: "Sign up", routerLink: "/signup", buttonClass: "fa-solid fa-arrow-up-right-from-square" }
  ];
  loginDone: boolean;
  FirstName: string;
  constructor(private _logHomeInteract: LoginToHomeInteractionService,private router: Router, private _tAService: TravelAwayServiceService) { }
    ngAfterContentChecked(): void {
      this.firstName = sessionStorage.getItem("FirstName");
    }
  ngOnInit(): void {
    if (sessionStorage.getItem("CustomerId") != null) {
      this.loginDone = true;
      this.firstName = sessionStorage.getItem("FirstName");
    } else {
      this.loginDone = false;
    }

    this._logHomeInteract.trueEmitter.subscribe(
      (responseData) => {
        this.loginDone = responseData;
      }
    );
    this.FirstName = sessionStorage.getItem('FirstName');
  }
  Logout() {
    this._tAService.LogoutCustomer({
      customerId: sessionStorage.getItem('CustomerId')
    }).subscribe(
      () => {
        console.log("Logout Successful");
        this.firstName = '';
      },
      () => { },
      () => { }
    );
    this._logHomeInteract.EmitFunction(false);
    sessionStorage.clear();
    this.router.navigate(['home'])
  }
  showDiv(collapser: HTMLDivElement) {
    collapser.hidden = !collapser.hidden;
  }
}

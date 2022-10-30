import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IButtonLink } from './TravelAway-Interfaces/ibutton-link';
import { LoginToHomeInteractionService } from './TravelAway-Services/login-to-home-interaction.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'TravelAway';
  buttonNameAndLinks: IButtonLink[] = [
    { buttonName: "Log In", routerLink: "/login", buttonClass: "fa-user" },
    { buttonName: "Sign up", routerLink: "/signup", buttonClass: "fa-solid fa-arrow-up-right-from-square" }
  ];
  loginDone: boolean;
  FirstName: string;
  constructor(private _logHomeInteract: LoginToHomeInteractionService) {}
  ngOnInit(): void {
    if (sessionStorage.getItem("CustomerId") != null) {
      this.loginDone = true;
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
    this._logHomeInteract.EmitFunction(false);
    sessionStorage.clear();
  }
}

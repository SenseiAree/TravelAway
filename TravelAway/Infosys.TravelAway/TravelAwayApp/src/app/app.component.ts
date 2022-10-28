import { Component } from '@angular/core';
import { IButtonLink } from './TravelAway-Interfaces/ibutton-link';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TravelAway';
  buttonNameAndLinks: IButtonLink[] = [
    { buttonName: "Log In", routerLink: "/login", buttonClass: "fa-user" },
    { buttonName: "Sign up", routerLink: "/signup", buttonClass: "fa-solid fa-arrow-up-right-from-square" }
    
  ]
}

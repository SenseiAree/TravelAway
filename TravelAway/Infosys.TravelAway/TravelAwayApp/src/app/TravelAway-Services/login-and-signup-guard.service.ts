import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginAndSignupGuardService implements CanActivate{

  constructor() { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean{
    return sessionStorage.getItem("CustomerId") == null;
  }
}

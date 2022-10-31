import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Error404PageNotFoundComponent } from './TravelAway-Components/error404-page-not-found/error404-page-not-found.component';
import { HomeComponent } from './TravelAway-Components/home/home.component';
import { LoginComponent } from './TravelAway-Components/login/login.component';
import { RegisterComponent } from './TravelAway-Components/register/register.component';
import { LoginAndSignupGuardService } from './TravelAway-Services/login-and-signup-guard.service';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent, canActivate: [LoginAndSignupGuardService]},
  { path: 'signup', component: RegisterComponent, canActivate: [LoginAndSignupGuardService] },
  { path: '#', component: HomeComponent },
  { path: '', component: HomeComponent },
  { path: '404Error', component: Error404PageNotFoundComponent },
  { path: '**', component: Error404PageNotFoundComponent }
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

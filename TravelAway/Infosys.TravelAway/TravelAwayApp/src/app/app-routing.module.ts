import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './TravelAway-Components/home/home.component';
import { LoginComponent } from './TravelAway-Components/login/login.component';
import { RegisterComponent } from './TravelAway-Components/register/register.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegisterComponent },
  { path: '#', component: HomeComponent },
  { path: '', component: HomeComponent }
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

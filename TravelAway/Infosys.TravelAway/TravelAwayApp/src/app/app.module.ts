import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './TravelAway-Components/login/login.component';
import { HomeComponent } from './TravelAway-Components/home/home.component';
import { RegisterComponent } from './TravelAway-Components/register/register.component';
import { FooterComponent } from './TravelAway-Components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ViewPackagesComponent } from './TravelAway-Components/view-packages/view-packages.component';
import { Error404PageNotFoundComponent } from './TravelAway-Components/error404-page-not-found/error404-page-not-found.component';
import { ViewProfileComponent } from './TravelAway-Components/view-profile/view-profile.component';

@NgModule({
  declarations: [

    AppComponent,

    LoginComponent,

    HomeComponent,

    RegisterComponent,

    FooterComponent, ViewPackagesComponent, Error404PageNotFoundComponent, ViewProfileComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './TravelAway-Components/login/login.component';
import { HomeComponent } from './TravelAway-Components/home/home.component';
import { RegisterComponent } from './TravelAway-Components/register/register.component';
import { EditProfileComponent } from './TravelAway-Components/edit-profile/edit-profile.component';
import { ViewProductsComponent } from './TravelAway-Components/view-products/view-products.component';
import { FooterComponent } from './TravelAway-Components/footer/footer.component';

@NgModule({
  declarations: [

    AppComponent,

    LoginComponent,

    HomeComponent,

    RegisterComponent,

    EditProfileComponent,

    ViewProductsComponent,

    FooterComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

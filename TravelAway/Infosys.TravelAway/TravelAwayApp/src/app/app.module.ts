import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NabvarComponent } from './nabvar/nabvar.component';
import { RegisterComponent } from './register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [

    AppComponent,
    NabvarComponent,
    RegisterComponent,
    NavbarComponent
    NabvarComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

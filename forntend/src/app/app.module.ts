import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { ContactComponent } from './contact/contact.component';
import { FlightSearchComponent } from './flight-search/flight-search.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { AddAirlineComponent } from './add-airline/add-airline.component';
import { AddAirlinelistComponent } from './add-airlinelist/add-airlinelist.component';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { TicketComponent } from './ticket/ticket.component';
import { GetByPNRComponent } from './get-by-pnr/get-by-pnr.component';
import { GetByEmailComponent } from './get-by-email/get-by-email.component';



@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    ContactComponent,
    FlightSearchComponent,
    HeaderComponent,
    LoginComponent,
    TicketComponent,
    AddAirlineComponent,
    AddFlightComponent,
    AddAirlinelistComponent,
    GetByPNRComponent,
    GetByEmailComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

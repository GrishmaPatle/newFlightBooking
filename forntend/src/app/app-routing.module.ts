import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAirlineComponent } from './add-airline/add-airline.component';
import { AddAirlinelistComponent } from './add-airlinelist/add-airlinelist.component';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightSearchComponent } from './flight-search/flight-search.component';
import { GetByEmailComponent } from './get-by-email/get-by-email.component';
import { GetByPNRComponent } from './get-by-pnr/get-by-pnr.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TicketComponent } from './ticket/ticket.component';

const routes: Routes = [
  {path: '',component:FlightSearchComponent},
  {path: 'login',component:LoginComponent},
  {path: 'addairline',component:AddAirlineComponent},
  {path: 'add-airlinelist',component:AddAirlinelistComponent},
  {path: 'add-flight',component:AddFlightComponent},
  {path: 'register',component:RegisterComponent},
  {path: 'flight-search',component:FlightSearchComponent},
  {path: 'contact',component:FlightSearchComponent},
  {path: 'get-by-pnr',component:GetByPNRComponent},
  {path: 'get-by-email',component:GetByEmailComponent},
  {path: 'booking/:airlineID/flight/:flightID',component:TicketComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
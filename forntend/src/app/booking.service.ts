import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const HttpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http : HttpClient) { }
  baseurl: string = 'https://localhost:44385/api/'


  BookTicket(data : any) : Observable<any>{
    console.log(data);
    return this.http.post(this.baseurl+'Booking/'+data.FlightId,data, HttpOption)
  }
}

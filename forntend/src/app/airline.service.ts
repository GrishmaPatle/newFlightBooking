import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const HttpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AirlineService {

  constructor(private http: HttpClient) { }

  baseurl: string = 'https://localhost:44364/api/'
  addAirline(data: any): Observable<any> {
    return this.http.post(this.baseurl + "Airlines", data, HttpOption)
  }


  getAllAirline(): Observable<any> {
    return this.http.get(this.baseurl + "Airlines")
  }

  addFlight(data: any): Observable<any> {
    return this.http.post(this.baseurl + "flights", data, HttpOption)
  }

  blockAirline(data: any): Observable<any> {
    return this.http.delete(this.baseurl + "Airlines/"+data)
  }
  
}

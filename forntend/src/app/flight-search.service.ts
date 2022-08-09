import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightSearchService {

  baseUrl = 'https://localhost:44385/api/'
  constructor(private http : HttpClient) { }


  searchFlight(data:any):Observable<any>{

    return this.http.post(this.baseUrl+'search',data);

  }
  
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PnrsearchService {

  baseUrl = 'https://localhost:44385/api/'
  searchForm: any;
  
  constructor(private http : HttpClient) { }


  searchFlight(pnr:any):Observable<any>{
    console.log(pnr);
    return this.http.get(this.baseUrl+'ticket/'+ pnr.pnr);
}
}
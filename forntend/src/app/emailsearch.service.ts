import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailValidator } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmailsearchService {

  baseUrl = 'https://localhost:44385/api/'
  searchForm: any;

  constructor(private http : HttpClient) { }

  searchFlight(emailid:any):Observable<any>{
    console.log(emailid);
    return this.http.get(this.baseUrl+'booking/history/'+ emailid.emailid);
}
}

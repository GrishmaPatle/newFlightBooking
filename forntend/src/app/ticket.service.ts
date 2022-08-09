import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http : HttpClient) { }
  
  baseurl : string = 'https://localhost:44385/api/';
  
  TicketSubmitted(data:any):Observable<any>{
    console.log(data);
    return this.http.post(this.baseurl+'booking/11',data);
}}


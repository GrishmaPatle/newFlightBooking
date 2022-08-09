import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http : HttpClient) { }
  
  baseurl : string = 'https://localhost:44385/api/';
  
  registerSubmitted(data:any):Observable<any>{
    console.log(data);
    return this.http.post(this.baseurl+'user',data);
}
}

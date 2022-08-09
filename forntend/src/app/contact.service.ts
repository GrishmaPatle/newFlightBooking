import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http : HttpClient) { }

  baseurl : string = 'https://localhost:44358/api/';

  public getContact():Observable<any>{
    return this.http.get(this.baseurl+"contacts");
  }

  public getContactByCity(city:string):Observable<any>{
    return this.http.get(this.baseurl+"contacts/"+city);
  }
  public getToken(){
    return this.http.get(this.baseurl+"token",{responseType: 'text'})

  }
}

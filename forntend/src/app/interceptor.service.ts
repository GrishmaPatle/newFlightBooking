import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactService } from './contact.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  token: string = "";

  constructor(private _contactService:ContactService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    
    req = req.clone({  
      setHeaders: {  
        Authorization: `Bearer ${localStorage.getItem("token")}`  
      }  
    });    
    
    return next.handle(req);  
    
  }
  
}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // uid:string = "admin@gmail.com";
  // pwd:string = "admin123";
  // result:string = "";

  LoginForm:FormGroup = new FormGroup({

    Email : new FormControl("", Validators.required),
    
    Password : new FormControl("", Validators.required),

  });

  constructor() { }

  ngOnInit(): void {
  }

  
   login_click(val:any):void
   {
    
    sessionStorage.setItem("AUTH_TOKEN",  "token");
    
   }
}

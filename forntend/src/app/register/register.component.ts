import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../register.service';
import { register } from 'src/Models/register.models';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  regflights:register[]|any;
  //regflights:any;
  
  constructor(private registerservice :RegisterService) { }

  ngOnInit(): void {
  }
  registerForm = new FormGroup({
    firstName : new FormControl('',[Validators.required,
      Validators.minLength(2),
      Validators.pattern("[a-zA-Z].*")
    ]),
    lastName: new FormControl("",[Validators.required,
    Validators.minLength(2),
    Validators.pattern("[a-zA-Z].*")
  ]),
  
    email:new FormControl('',[Validators.required,Validators.email]),
    password:new FormControl("",[Validators.required]),
    contactNumber:new FormControl('',[
    Validators.required,
    Validators.minLength(10),
    Validators.maxLength(10),
    Validators.pattern("[0-9]*"),
]),

    role:new FormControl('',[Validators.required]),
    age:new FormControl('',[Validators.required]),
    gender:new FormControl('',[Validators.required]),
    address1:new FormControl('',[Validators.required]),
    address2:new FormControl('',[Validators.required]),
    pincode:new FormControl('',[Validators.required])

  });


get FirstName():FormControl {
  return this.registerForm.get("firstName") as FormControl;
}
get LastName():FormControl {
  return this.registerForm.get("lastName") as FormControl;
}

get Emailaddress():FormControl {
  return this.registerForm.get("email") as FormControl;
}

get Password():FormControl {
  return this.registerForm.get("password") as FormControl;
}

get ContactNumber(): FormControl{
  return this.registerForm.get("contactNumber") as FormControl;
}

get Role():FormControl {
  return this.registerForm.get("role") as FormControl;
}

get Age():FormControl {
  return this.registerForm.get("age") as FormControl;
}

get Gender():FormControl {
  return this.registerForm.get("gender") as FormControl;
}

get Address1():FormControl {
  return this.registerForm.get("address1") as FormControl;
}

get Address2():FormControl {
  return this.registerForm.get("address2") as FormControl;
}

get Pincode():FormControl {
  return this.registerForm.get("pincode") as FormControl;
}
registerSubmitted(val:any){
  this.registerservice.registerSubmitted(val).subscribe(data => {
    //this.regflights=data.result;
    this.regflights=data;
    console.log(this.regflights);
  })
 }
}



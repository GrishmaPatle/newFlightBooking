import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AirlineService } from '../airline.service';

@Component({
  selector: 'app-add-airline',
  templateUrl: './add-airline.component.html',
  styleUrls: ['./add-airline.component.css']
})
export class AddAirlineComponent implements OnInit {

  addAirlineForm!:FormGroup;

  constructor(private airline : AirlineService) { }

  ngOnInit(): void {
    this.addAirlineForm = new FormGroup({
      Name :new FormControl('',[Validators.required]),
      Owner :new FormControl('',[Validators.required]),
      Logo :new FormControl('',[Validators.required]),
      ContactNumber :new FormControl('',[Validators.required])
    
     
    })

  }


  AddAirline(val:any){
    this.airline.addAirline(val).subscribe(data => {
      if(data){
        alert("saved sucessfully")
      }
    });
  }

}

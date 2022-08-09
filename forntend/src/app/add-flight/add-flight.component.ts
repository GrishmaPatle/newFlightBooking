import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AirlineService } from '../airline.service';

@Component({
  selector: 'app-add-flight',
  templateUrl: './add-flight.component.html',
  styleUrls: ['./add-flight.component.css']
})
export class AddFlightComponent implements OnInit {

  addFlightsForm!: FormGroup;
  // AirlineId: any = 1;
  constructor(private airlineservice: AirlineService) { }

  ngOnInit(): void {

    this.addFlightsForm = new FormGroup({
      Name: new FormControl('', [Validators.required]),
      FlightNumber: new FormControl('', [Validators.required]),
      FromPlace: new FormControl('', [Validators.required]),
      ToPlace: new FormControl('', [Validators.required]),
      StartDateTime: new FormControl('', [Validators.required]),
      EndDateTime: new FormControl('', [Validators.required]),
      ScheduledDays: new FormControl('', [Validators.required]),
      InstumentUsed: new FormControl('', [Validators.required]),
      TotalNumberOfBusinessClassSeats: new FormControl('', [Validators.required]),
      TotalNumberOfNonBusinessClassSeats: new FormControl('', [Validators.required]),
      CostOfBusinessClassSeats: new FormControl('', [Validators.required]),
      CostOfNumberOfNonBusinessClassSeats: new FormControl('', [Validators.required]),
      TotalCost: new FormControl('', [Validators.required]),
      NumberOfRows: new FormControl('', [Validators.required]),
      MealType: new FormControl('', [Validators.required]),
      AirlineId: new FormControl(2, [Validators.required]),


    })
  }



  AddFlight(val: any) {
    this.airlineservice.addFlight(val).subscribe(data => {
      if(data){
        alert("Flight Added successfully")
      }
    })
  }
}



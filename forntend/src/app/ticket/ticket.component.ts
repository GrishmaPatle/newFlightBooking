import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../booking.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  TicketForm!:FormGroup;
  constructor(private param: ActivatedRoute,private bookingservice : BookingService) { }

  PNR:number =0;

  ngOnInit(): void {

    this.TicketForm = new FormGroup({
      PassengerName :new FormControl('',[Validators.required]),
      PassengerEmail :new FormControl('',[Validators.required]),
      Gender :new FormControl('',[Validators.required]),
      Age :new FormControl('',[Validators.required]),
      OptForMeal :new FormControl('',[Validators.required]),
      SeatNumber :new FormControl('',[Validators.required]),
      saetcost :new FormControl('',[Validators.required]),
      discount :new FormControl('',[Validators.required]),
     
    })
  }


  TicketBook(val:any){
   let  sendObj = {
      "AirlineId" :  5,
      "FlightId" :  this.param.snapshot.params['flightID'],
      "UserId" :  1,
      "PassengerName": val.PassengerName,
      "PassengerEmail": val.PassengerEmail,
      "Gender": val.Gender,
      "OptForMeal": val.OptForMeal,
      "SeatNumber": val.SeatNumber,
      "seatcost":val.seatcost,
      "discount":val.discount
    }


    this.bookingservice.BookTicket(sendObj).subscribe(data => {
      console.log(data);
      this.PNR = data.pnr
    })
  }
}

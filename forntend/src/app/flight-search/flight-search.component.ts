import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { FlightSearchService } from '../flight-search.service';

@Component({
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})
export class FlightSearchComponent implements OnInit {
  searchForm!: FormGroup;
  flights: any ;

  constructor( private searchservice : FlightSearchService, private router: Router) { }

  ngOnInit(): void {

    this.searchForm = new FormGroup({
      fromDate :new FormControl('',[Validators.required]),
      toDate :new FormControl('',[Validators.required]),
      FromPlace :new FormControl('',[Validators.required]),
      ToPlace :new FormControl('',[Validators.required]),
    }
    )
  }

  onSearchClick(val:any){
   this.searchservice.searchFlight(val).subscribe(data => {
    // console.log(data.result);
    this.flights=data.result;
   })
  }



  onBooking(id:number,flightid:number){
    // alert(id);
    this.router.navigate(['booking/'+id+'/flight/'+flightid])
    //this.router.navigate(['register'+id+'/flight/'+registerid])
  }
}

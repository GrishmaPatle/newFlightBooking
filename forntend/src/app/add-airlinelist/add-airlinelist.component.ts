import { Component, OnInit } from '@angular/core';
import { AirlineService } from '../airline.service';

@Component({
  selector: 'app-add-airlinelist',
  templateUrl: './add-airlinelist.component.html',
  styleUrls: ['./add-airlinelist.component.css']
})
export class AddAirlinelistComponent implements OnInit {
  
  arilines:any;
  constructor(private airlineservice : AirlineService) { }

  ngOnInit(): void {
    this.getAllAirline();
    //this.deleteAirline();
  }

  getAllAirline(){
this.airlineservice.getAllAirline().subscribe(data => {
  this.arilines = data;
})
  }

  Delete(id:number){
    alert(id);
    this.airlineservice.blockAirline(id).subscribe(data => {
      if(data){
        this.getAllAirline();
      }
    })
}
}
function data(data: any) {
  throw new Error('Function not implemented.');
}


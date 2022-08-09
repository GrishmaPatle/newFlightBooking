import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PnrsearchService } from '../pnrsearch.service';

@Component({
  selector: 'app-get-by-pnr',
  templateUrl: './get-by-pnr.component.html',
  styleUrls: ['./get-by-pnr.component.css']
})
export class GetByPNRComponent implements OnInit {
  searchForm!: FormGroup;
  flights: any;

  constructor(private searchservice :PnrsearchService, private router: Router) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      pnr :new FormControl('',[Validators.required]),
    }
    )
  }
  onSearchClick(val:any){
    this.searchservice.searchFlight(val).subscribe(data => {
    //console.log(data.result);  
     console.log(data);
     this.flights=data;
    })
   }
}
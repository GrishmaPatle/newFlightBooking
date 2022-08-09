import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmailsearchService } from '../emailsearch.service';

@Component({
  selector: 'app-get-by-email',
  templateUrl: './get-by-email.component.html',
  styleUrls: ['./get-by-email.component.css']
})
export class GetByEmailComponent implements OnInit {
  searchForm!: FormGroup;
  flights: any;

  constructor(private searchservice :EmailsearchService, private router: Router) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      emailid :new FormControl('',[Validators.required]),
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
  

import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor(private _contactService: ContactService) { }

  contactss : any[] = [];


  ngOnInit(): void {
    this._contactService.getToken().subscribe(token => {
      localStorage.setItem("token", token.toString());
    });
  }


  getAllContacts(){
    this._contactService.getContact().subscribe(data => {
      this.contactss = data;
      console.log(this.contactss);
    });
  }



  getContactByCity(city: string){

      this._contactService.getContactByCity(city).subscribe(data =>{
        this.contactss = data;
        console.log(this.contactss);
        
      });
  }

}

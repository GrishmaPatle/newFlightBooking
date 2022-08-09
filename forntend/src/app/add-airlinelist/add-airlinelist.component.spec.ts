import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAirlinelistComponent } from './add-airlinelist.component';

describe('AddAirlinelistComponent', () => {
  let component: AddAirlinelistComponent;
  let fixture: ComponentFixture<AddAirlinelistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAirlinelistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAirlinelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

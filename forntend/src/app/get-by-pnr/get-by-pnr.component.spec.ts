import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetByPNRComponent } from './get-by-pnr.component';

describe('GetByPNRComponent', () => {
  let component: GetByPNRComponent;
  let fixture: ComponentFixture<GetByPNRComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetByPNRComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetByPNRComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

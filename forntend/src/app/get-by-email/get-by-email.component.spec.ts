import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetByEmailComponent } from './get-by-email.component';

describe('GetByEmailComponent', () => {
  let component: GetByEmailComponent;
  let fixture: ComponentFixture<GetByEmailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetByEmailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetByEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

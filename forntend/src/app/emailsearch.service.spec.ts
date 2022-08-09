import { TestBed } from '@angular/core/testing';

import { EmailsearchService } from './emailsearch.service';

describe('EmailsearchService', () => {
  let service: EmailsearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmailsearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { PnrsearchService } from './pnrsearch.service';

describe('PnrsearchService', () => {
  let service: PnrsearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PnrsearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

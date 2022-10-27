import { TestBed } from '@angular/core/testing';

import { TravelAwayServiceService } from './travel-away-service.service';

describe('TravelAwayServiceService', () => {
  let service: TravelAwayServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TravelAwayServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

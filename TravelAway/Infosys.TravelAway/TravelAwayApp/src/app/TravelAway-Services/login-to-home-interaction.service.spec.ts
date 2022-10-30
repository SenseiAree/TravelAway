import { TestBed } from '@angular/core/testing';

import { LoginToHomeInteractionService } from './login-to-home-interaction.service';

describe('LoginToHomeInteractionService', () => {
  let service: LoginToHomeInteractionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginToHomeInteractionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { LoginAndSignupGuardService } from './login-and-signup-guard.service';

describe('LoginAndSignupGuardService', () => {
  let service: LoginAndSignupGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginAndSignupGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

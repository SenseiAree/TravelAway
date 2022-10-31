import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Error404PageNotFoundComponent } from './error404-page-not-found.component';

describe('Error404PageNotFoundComponent', () => {
  let component: Error404PageNotFoundComponent;
  let fixture: ComponentFixture<Error404PageNotFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Error404PageNotFoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Error404PageNotFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EndreComponent } from './endre.component';

describe('EndreComponent', () => {
  let component: EndreComponent;
  let fixture: ComponentFixture<EndreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EndreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EndreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

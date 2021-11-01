import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogginnComponent } from './logginn.component';

describe('LogginnComponent', () => {
  let component: LogginnComponent;
  let fixture: ComponentFixture<LogginnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogginnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogginnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

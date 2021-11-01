import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LagreComponent } from './lagre.component';

describe('LagreComponent', () => {
  let component: LagreComponent;
  let fixture: ComponentFixture<LagreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LagreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LagreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

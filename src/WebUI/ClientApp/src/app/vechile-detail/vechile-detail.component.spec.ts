import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VechileDetailComponent } from './vechile-detail.component';

describe('VechileDetailComponent', () => {
  let component: VechileDetailComponent;
  let fixture: ComponentFixture<VechileDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VechileDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VechileDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

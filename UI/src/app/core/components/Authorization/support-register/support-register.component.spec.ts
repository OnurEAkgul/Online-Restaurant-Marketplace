import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportRegisterComponent } from './support-register.component';

describe('SupportRegisterComponent', () => {
  let component: SupportRegisterComponent;
  let fixture: ComponentFixture<SupportRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupportRegisterComponent]
    });
    fixture = TestBed.createComponent(SupportRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

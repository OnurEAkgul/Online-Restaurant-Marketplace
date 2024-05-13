import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopOwnerRegisterComponent } from './shop-owner-register.component';

describe('ShopOwnerRegisterComponent', () => {
  let component: ShopOwnerRegisterComponent;
  let fixture: ComponentFixture<ShopOwnerRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShopOwnerRegisterComponent]
    });
    fixture = TestBed.createComponent(ShopOwnerRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

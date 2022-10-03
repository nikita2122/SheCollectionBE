import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePromotionComponent } from './create-promotion.component';

describe('CreatePromotionComponent', () => {
  let component: CreatePromotionComponent;
  let fixture: ComponentFixture<CreatePromotionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePromotionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePromotionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

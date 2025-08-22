import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardDemo } from './card-demo';

describe('CardDemo', () => {
  let component: CardDemo;
  let fixture: ComponentFixture<CardDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardDemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardDemo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

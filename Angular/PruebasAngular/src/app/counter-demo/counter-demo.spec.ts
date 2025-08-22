import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterDemo } from './counter-demo';

describe('CounterDemo', () => {
  let component: CounterDemo;
  let fixture: ComponentFixture<CounterDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CounterDemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CounterDemo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

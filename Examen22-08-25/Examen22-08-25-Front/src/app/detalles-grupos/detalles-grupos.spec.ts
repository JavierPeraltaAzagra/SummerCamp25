import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesGrupos } from './detalles-grupos';

describe('DetallesGrupos', () => {
  let component: DetallesGrupos;
  let fixture: ComponentFixture<DetallesGrupos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetallesGrupos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetallesGrupos);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

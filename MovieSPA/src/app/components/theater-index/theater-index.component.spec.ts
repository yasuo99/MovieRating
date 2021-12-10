import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheaterIndexComponent } from './theater-index.component';

describe('TheaterIndexComponent', () => {
  let component: TheaterIndexComponent;
  let fixture: ComponentFixture<TheaterIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheaterIndexComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

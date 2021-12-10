import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheaterManagerComponent } from './theater-manager.component';

describe('TheaterManagerComponent', () => {
  let component: TheaterManagerComponent;
  let fixture: ComponentFixture<TheaterManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheaterManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

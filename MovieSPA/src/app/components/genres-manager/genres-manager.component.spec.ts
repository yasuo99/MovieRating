import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenresManagerComponent } from './genres-manager.component';

describe('GenresManagerComponent', () => {
  let component: GenresManagerComponent;
  let fixture: ComponentFixture<GenresManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenresManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenresManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

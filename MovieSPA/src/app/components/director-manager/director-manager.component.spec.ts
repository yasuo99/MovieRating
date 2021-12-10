import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirectorManagerComponent } from './director-manager.component';

describe('DirectorManagerComponent', () => {
  let component: DirectorManagerComponent;
  let fixture: ComponentFixture<DirectorManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DirectorManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DirectorManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

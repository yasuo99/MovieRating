import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActorManagerComponent } from './actor-manager.component';

describe('ActorManagerComponent', () => {
  let component: ActorManagerComponent;
  let fixture: ComponentFixture<ActorManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActorManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActorManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActorIndexComponent } from './actor-index.component';

describe('ActorIndexComponent', () => {
  let component: ActorIndexComponent;
  let fixture: ComponentFixture<ActorIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActorIndexComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActorIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

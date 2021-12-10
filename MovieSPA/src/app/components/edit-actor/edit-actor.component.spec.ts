import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditActorComponent } from './edit-actor.component';

describe('EditActorComponent', () => {
  let component: EditActorComponent;
  let fixture: ComponentFixture<EditActorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditActorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditActorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

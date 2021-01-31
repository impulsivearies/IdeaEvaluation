import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdeapanelComponent } from './ideapanel.component';

describe('IdeapanelComponent', () => {
  let component: IdeapanelComponent;
  let fixture: ComponentFixture<IdeapanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IdeapanelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IdeapanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

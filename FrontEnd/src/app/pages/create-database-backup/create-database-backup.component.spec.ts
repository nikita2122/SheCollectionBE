import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDatabaseBackupComponent } from './create-database-backup.component';

describe('CreateDatabaseBackupComponent', () => {
  let component: CreateDatabaseBackupComponent;
  let fixture: ComponentFixture<CreateDatabaseBackupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDatabaseBackupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDatabaseBackupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

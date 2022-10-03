import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatabaseBackupsComponent } from './database-backups.component';

describe('DatabaseBackupsComponent', () => {
  let component: DatabaseBackupsComponent;
  let fixture: ComponentFixture<DatabaseBackupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatabaseBackupsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DatabaseBackupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

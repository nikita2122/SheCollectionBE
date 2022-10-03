import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { UrlConstants } from './constants';
import { AppState } from './store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  isAdmin: boolean = false;
  private subscriptions: Subscription[] = [];

  constructor(private store: Store<AppState>, private router: Router) {
    this.subscriptions.push(
      this.store.select('AuthStore').subscribe((userStore) => {
        if (userStore !== undefined) {
          this.isAdmin = userStore.admin;
        } else {
          this.isAdmin = false;
        }
      })
    );
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }
}

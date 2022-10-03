import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { UrlConstants } from 'src/app/constants';
import { AppState } from 'src/app/store';

@Component({
  selector: 'app-main-navbar',
  templateUrl: './main-navbar.component.html',
  styleUrls: ['./main-navbar.component.scss'],
})
export class MainNavbarComponent implements OnInit, OnDestroy {
  loggedIn: boolean = false;
  storeSub!: Subscription;

  links: { label: string; url: string }[] = [];

  constructor(private store: Store<AppState>) {
    this.storeSub = this.store.select('AuthStore').subscribe((store) => {
      if (store !== undefined) this.loggedIn = true;
      else this.loggedIn = false;

      this.links = [
        { label: 'PRODUCTS', url: UrlConstants.categories + '/products' },
        { label: 'SERVICES', url: UrlConstants.categories + '/services' },
        { label: 'PROMOTIONS', url: UrlConstants.promotions },
      ];

      if (this.loggedIn) {
        this.links = this.links.concat([
          { label: 'BOOKINGS', url: UrlConstants.bookings },
          { label: 'ORDERS', url: UrlConstants.orders },
        ]);
      }
    });
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.storeSub.unsubscribe();
  }
}

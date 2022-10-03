import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent implements OnInit {
  private userId!: number;
  constructor(private router: Router, private store: Store<AppState>) {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) this.userId = store.userId;
        else this.router.navigate([UrlConstants.home]);
      });
  }

  ngOnInit(): void {}

  viewDetails() {
    this.router.navigate([UrlConstants.update_account + '/' + this.userId]);
  }

  updatePassword() {
    this.router.navigate([UrlConstants.update_passwd]);
  }
}

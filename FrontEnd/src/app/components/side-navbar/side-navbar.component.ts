import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { UrlConstants } from 'src/app/constants';
import { AppState } from 'src/app/store';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-side-navbar',
  templateUrl: './side-navbar.component.html',
  styleUrls: ['./side-navbar.component.scss'],
})
export class SideNavbarComponent implements OnInit {
  userId!: number;
  links!: { label: string; url: string }[];

  constructor(private router: Router, private store: Store<AppState>) {}

  ngOnInit(): void {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) {
          this.userId = store.userId;

          this.links = [
            {
              label: 'View My Account',
              url: UrlConstants.update_account + '/' + this.userId,
            },
            {
              label: 'Booking Management',
              url: UrlConstants.booking_management,
            },
            {
              label: 'Customer Management',
              url: UrlConstants.customer_management,
            },
            {
              label: 'Employee Management',
              url: UrlConstants.employee_management,
            },
            {
              label: 'Service Management',
              url: UrlConstants.service_management,
            },
            {
              label: 'Inventory Management',
              url: UrlConstants.inventory_management,
            },
            {
              label: 'Product Management',
              url: UrlConstants.product_management,
            },
            { label: 'Order Management', url: UrlConstants.order_management },
            { label: 'Reports', url: UrlConstants.reports },
            //{ label: 'Promotion management', url: UrlConstants.promotions+'/admin' },
            { label: 'Promotion management', url: UrlConstants.promotions+'/admin/list' },
            { label: 'Communification management', url: '/admin/notification' },
            { label: 'Database management', url: 'admin/database' },
            { label: 'Log Out', url: UrlConstants.logout },
          ];
        } else this.router.navigate([UrlConstants.logout]);
      });
  }

  navigate(url: string) {
    this.router.navigate([url]);
  }
}

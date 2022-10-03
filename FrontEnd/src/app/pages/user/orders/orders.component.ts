import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { Order } from 'src/app/models/order/order';
import { OrderService } from 'src/app/services/order.service';
import { AppState } from 'src/app/store';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];

  constructor(
    private orderService: OrderService,
    private store: Store<AppState>,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) {
          const userId: number = store?.userId;
          this.orderService
            .getOrders(userId)
            .pipe(take(1))
            .subscribe({
              next: (res) => {
                this.orders = res;
                console.log(res);
              },
              error: () => {
                console.log('woops');
              },
            });
        }
      });
  }

  back() {
    this.router.navigate(['..']);
  }
}

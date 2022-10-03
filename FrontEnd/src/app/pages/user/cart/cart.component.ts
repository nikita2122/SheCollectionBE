import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Cart } from 'src/app/models/cart/cart';
import { CartLine } from 'src/app/models/cart/cartLine';
import { CartService } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';
import { AppState } from 'src/app/store';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  loading: boolean = true;
  empty: boolean = true;
  cartLines: CartLine[] = [];
  userId!: number;
  imgUrl: string = environment.apiUrl + 'File/download/';

  constructor(
    private router: Router,
    private store: Store<AppState>,
    private cartService: CartService,
    private orderService: OrderService
  ) {}

  ngOnInit(): void {
    this.loading = false;
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) {
          this.userId = store.userId;

          this.cartService
            .getCartLines(store.userId)
            .pipe(take(1))
            .subscribe((cartLines) => {
              if (cartLines.length > 0) {
                this.empty = false;
                this.cartLines = cartLines;
              }
            });
        }
      });
  }

  checkout() {
    if (this.userId !== undefined)
      this.orderService
        .OrderCart(this.userId)
        .pipe(take(1))
        .subscribe({
          next: () => this.router.navigate([UrlConstants.home]),
        });
  }

  clear() {
    this.cartService
      .clearCart(this.userId)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.empty = true;
          this.cartLines = [];
        },
      });
  }

  deleteLine(cartLineId: number) {
    this.cartService
      .deleteCartLine(cartLineId)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.cartLines.splice(
            this.cartLines.findIndex((l) => l.cartLineId === cartLineId),
            1
          );
        },
      });
  }
}

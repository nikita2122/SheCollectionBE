import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CartLine } from '../models/cart/cartLine';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartUrl = environment.apiUrl + 'Cart/';

  constructor(private http: HttpClient) {}

  addToCart(
    productId: number,
    amount: number,
    colourId: number,
    sizeId: number,
    userId: number
  ): Observable<any> {
    return this.http.post(this.cartUrl + 'AddToCart', {
      productId,
      amount,
      colourId,
      sizeId,
      userId,
    });
  }

  getCartLines(userId: number): Observable<CartLine[]> {
    return this.http.get<CartLine[]>(this.cartUrl + 'GetCartLines', {
      params: new HttpParams().set('userId', userId),
    });
  }

  clearCart(userId: number): Observable<any> {
    return this.http.get<CartLine[]>(this.cartUrl + 'ClearCart', {
      params: new HttpParams().set('userId', userId),
    });
  }

  deleteCartLine(lineId: number): Observable<any> {
    return this.http.delete<CartLine[]>(this.cartUrl + 'DeleteCartLine', {
      params: new HttpParams().set('lineId', lineId),
    });
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../models/order/order';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private orderUrl = environment.apiUrl + 'Order/';

  constructor(private http: HttpClient) {}

  OrderCart(userId: number) {
    return this.http.post(this.orderUrl + 'OrderCart', userId);
  }

  getOrders(userId: number): Observable<Order[]> {
    return this.http.get<Order[]>(this.orderUrl + 'GetOrdersByUserId', {
      params: new HttpParams().set('userId', userId),
    });
  }

  getReport(date: Date): Observable<Order[]> {
    return this.http.get<Order[]>(this.orderUrl + 'GenerateReport', {
      params: new HttpParams().set(
        'date',
        date.getFullYear() +
          '-' +
          (date.getMonth() + 1) +
          '-' +
          date.getDate() +
          'T00:00:00'
      ),
    });
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/user/Customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private customerUrl: string = environment.apiUrl + 'Customer/';

  constructor(private http: HttpClient) {}

  getCustomerDetails(userId: number): Observable<Customer> {
    return this.http.get<Customer>(this.customerUrl + 'GetCustomer', {
      params: new HttpParams().set('userId', userId),
    });
  }
}

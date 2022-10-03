import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TimeSlot } from '../models/services/TimeSlot';
import { MakeBookingModel } from '../models/booking/MakeBookingModel';
import { Booking } from '../models/booking/booking';

@Injectable({
  providedIn: 'root',
})
export class BookingsService {
  private bookingUrl = environment.apiUrl + 'Booking/';

  constructor(private http: HttpClient) {}

  getTimeSlots(date: Date): Observable<TimeSlot[]> {
    return this.http.get<TimeSlot[]>(this.bookingUrl + 'GetTimeSlots', {
      params: new HttpParams().set(
        'date',
        date.getFullYear() +
          '-' +
          date.getMonth() +
          '-' +
          date.getDate() +
          ' 00:00:00'
      ),
    });
  }

  makeBooking(model: MakeBookingModel) {
    return this.http.post<TimeSlot[]>(this.bookingUrl + 'MakeBooking', model);
  }

  getBookingsByUserId(id: number): Observable<Booking[]> {
    return this.http.get<Booking[]>(this.bookingUrl + 'GetByUserId', {
      params: new HttpParams().set('userId', id),
    });
  }

  getBookingById(bookingId: number): Observable<Booking> {
    return this.http.get<Booking>(this.bookingUrl + 'GetById', {
      params: new HttpParams().set('bookingId', bookingId),
    });
  }

  getSlotById(id: number): Observable<any> {
    return this.http.get<any>(this.bookingUrl + 'GetSlotById', {
      params: new HttpParams().set('id', id),
    });
  }

  cancelBooking(bookingId: number) {
    return this.http.get(this.bookingUrl + 'Cancel', {
      params: new HttpParams().set('bookingId', bookingId),
    });
  }
}

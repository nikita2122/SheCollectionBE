import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Booking } from 'src/app/models/booking/booking';
import { BookingsService } from 'src/app/services/bookings.service';
import { AppState } from 'src/app/store';

@Component({
  selector: 'app-view-booking',
  templateUrl: './view-booking.component.html',
  styleUrls: ['./view-booking.component.scss'],
})
export class ViewBookingComponent implements OnInit {
  bookings: Booking[] = [];
  filteredBookings: Booking[] = [];
  loading: boolean = true;

  constructor(
    private router: Router,
    private bookingService: BookingsService,
    private store: Store<AppState>
  ) {}

  ngOnInit(): void {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) {
          this.bookingService
            .getBookingsByUserId(store.userId)
            .pipe(take(1))
            .subscribe((res) => {
              console.log(res);
              this.filteredBookings = this.bookings = res;
              this.loading = false;
            });
        }
      });
  }

  search($event: any) {
    this.filteredBookings = this.bookings.filter((b) =>
      b.serviceTable.serviceName.toLowerCase().includes($event.toLowerCase())
    );
  }

  viewBooking(bookingId: number) {
    this.router.navigate([UrlConstants.view_booking + '/' + bookingId]);
  }
}

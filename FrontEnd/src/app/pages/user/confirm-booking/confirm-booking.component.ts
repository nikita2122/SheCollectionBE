import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { MakeBookingModel } from 'src/app/models/booking/MakeBookingModel';
import { Service } from 'src/app/models/services/Service';
import { TimeSlot } from 'src/app/models/services/TimeSlot';
import { staffMember } from 'src/app/models/user/StaffMember';
import { BookingsService } from 'src/app/services/bookings.service';
import { ServicesService } from 'src/app/services/services.service';
import { StaffService } from 'src/app/services/staff.service';
import { AppState } from 'src/app/store';

@Component({
  selector: 'app-confirm-booking',
  templateUrl: './confirm-booking.component.html',
  styleUrls: ['./confirm-booking.component.scss'],
})
export class ConfirmBookingComponent implements OnInit {
  loading: boolean = true;
  viewing: boolean = false;

  timeSlot!: TimeSlot;
  date!: Date;
  staffMember!: staffMember;
  service!: Service;
  userId!: number;
  bookingId!: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private bookingService: BookingsService,
    private staffService: StaffService,
    private servicesService: ServicesService,
    private store: Store<AppState>
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const timeSlotId = params.get('timeSlotId');
      const date = params.get('date');
      const staffMemberId = params.get('staffMemberId');
      const serviceId = params.get('serviceId');
      const bookingId = params.get('bookingId');

      if (
        timeSlotId !== null &&
        date !== null &&
        staffMemberId !== null &&
        serviceId !== null
      ) {

        this.getBooking(
          +timeSlotId,
          new Date(date),
          +staffMemberId,
          +serviceId
        );
      } else if (bookingId !== null) {
        this.viewing = true;
        this.bookingId = +bookingId;
        this.bookingService
          .getBookingById(+bookingId)
          .pipe(take(1))
          .subscribe((res) => {
            console.log(res);
            this.getBooking(
              res.timeslot.timeslotId,
              new Date(res.schedule.date),
              res.employee.employeeId,
              res.serviceTable.serviceTableId
            );
          });
      } else {
        this.router.navigate([UrlConstants.home]);
      }
    });
  }

  getBooking(
    timeSlotId: number,
    date: Date,
    staffMemberId: number,
    serviceId: number
  ) {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined) {
          this.userId = store.userId;
          this.date = new Date(date);

          this.staffService
            .getStaffMemberById(+staffMemberId)
            .pipe(take(1))
            .subscribe((res) => {
              this.staffMember = res;
              this.servicesService
                .getServiceById(+serviceId)
                .pipe(take(1))
                .subscribe((res) => {
                  this.service = res;
                  this.bookingService
                    .getSlotById(+timeSlotId)
                    .pipe(take(1))
                    .subscribe((res) => {
                      
                      if (res !== undefined) this.timeSlot = res;
                      this.loading = false;
                    });
                });
            });
        } else {
          this.router.navigate([UrlConstants.home]);
        }
      });
  }

  back() {
    if (this.viewing) {
      this.router.navigate([UrlConstants.view_bookings]);
    } else {
      this.router.navigate([
        UrlConstants.select_date +
          '/' +
          this.service.serviceTableId +
          '/' +
          this.staffMember.employeeId,
      ]);
    }
  }

  makeBooking() {
    const model: MakeBookingModel = {
      date:
        this.date.getFullYear() +
        '-' +
        (+this.date.getMonth() < 9
          ? '0' + (this.date.getMonth() + 1)
          : this.date.getMonth() + 1) +
        '-' +
        this.date.getDate() +
        'T00:00:00',
      serviceId: this.service.serviceTableId,
      staffMemberId: this.staffMember.employeeId,
      timeSlotId: this.timeSlot.timeslotId,
      userId: this.userId,
    };

    this.bookingService
      .makeBooking(model)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.router.navigate([UrlConstants.bookings]);
        },
      });
  }

  update() {}

  reschedule() {}

  cancelBooking() {
    this.bookingService
      .cancelBooking(this.bookingId)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.router.navigate([UrlConstants.view_bookings]);
        },
      });
  }
}

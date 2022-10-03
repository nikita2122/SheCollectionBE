import { animateChild } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { TimeSlot } from 'src/app/models/services/TimeSlot';
import { BookingsService } from 'src/app/services/bookings.service';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-select-date',
  templateUrl: './select-date.component.html',
  styleUrls: ['./select-date.component.scss'],
})
export class SelectDateComponent implements OnInit {
  loading: boolean = true;
  currentDate: Date = new Date();
  selectedDate = new Date();
  currentYear!: number;
  currentMonth!: number;
  currentDay!: number;
  selectedDay: number = new Date().getDate();
  timeSlots: TimeSlot[] = [];
  selectedTimeSlotId!: number;

  AmountOfDays: number[];

  firstDayOfMonth: number = 0;

  week: string[] = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

  dayOfWeek: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private bookingService: BookingsService
  ) {
    this.updateDate();

    this.AmountOfDays = Array.from(
      Array(
        this.getAmountOfDaysInMonth(this.currentMonth, this.currentYear)
      ).keys()
    );

    this.AmountOfDays = this.AmountOfDays.slice(1, this.AmountOfDays.length);
    this.AmountOfDays.push(this.AmountOfDays.length + 1);

    this.dayOfWeek = new Date(
      this.currentYear,
      this.currentMonth - 1,
      1
    ).getDay();

    const arr: number[] = new Array(this.dayOfWeek);

    this.AmountOfDays.unshift(...arr);

    this.bookingService
      .getTimeSlots(this.selectedDate)
      .pipe(take(1))
      .subscribe((res) => {
        this.timeSlots = res;
        console.log(res);
        this.loading = false;
      });
  }

  ngOnInit(): void {}

  getAmountOfDaysInMonth(month: number, year: number): number {
    const halfAnum = Math.ceil(month / 7);

    if (halfAnum === 1) {
      if (month === 2) {
        if (year % 4 === 0) {
          return 29;
        } else {
          return 28;
        }
      } else {
        return 30 + (month % 2);
      }
    } else {
      return 31 - (month % 2);
    }
  }

  updateDate() {
    this.currentYear = this.selectedDate.getFullYear();
    this.currentMonth = this.selectedDate.getMonth() + 1;
    this.currentDay = this.selectedDate.getDate();
  }

  selectDay(day: number) {
    if (day !== undefined && day >= new Date().getDate()) {
      this.selectedDay = day;
      this.selectedDate = new Date(
        this.currentYear,
        this.currentMonth - 1,
        day
      );
      this.bookingService
        .getTimeSlots(this.selectedDate)
        .pipe(take(1))
        .subscribe((res) => {
          this.timeSlots = res;
        });
    }
  }

  selectTime(timeSlotId: number) {
    if (this.timeSlots.find((t) => t.timeslotId === timeSlotId)?.available) {
      this.selectedTimeSlotId = timeSlotId;
    }
  }

  changeMonth(amount: number) {
    if (amount === 1) {
      if (this.currentMonth === 12) {
        this.selectedDate = new Date(this.currentYear + 1, 0, this.selectedDay);
      } else {
        this.selectedDate = new Date(
          this.currentYear,
          this.currentMonth,
          this.selectedDay
        );
      }
    } else {
      if (
        this.selectedDate.getMonth() > this.currentDate.getMonth() &&
        this.selectedDate.getFullYear() >= this.currentDate.getFullYear()
      )
        if (this.currentMonth === 1) {
          this.selectedDate = new Date(
            this.currentYear - 1,
            0,
            this.selectedDay
          );
        } else {
          this.selectedDate = new Date(
            this.currentYear,
            this.currentMonth - 2,
            this.selectedDay
          );
        }
    }
    this.updateDate();
  }
  ignore(day: number) {
    return (
      (this.currentYear <= this.currentDate.getFullYear() &&
        this.currentMonth - 1 <= this.currentDate.getMonth() &&
        day < this.currentDate.getDate()) ||
      day === undefined
    );
  }
  next() {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const serviceId = params.get('serviceId');
      const empId = params.get('staffMemberId');
      const date: string =
        this.selectedDate.getFullYear() +
        '-' +
        this.selectedDate.getMonth() +
        '-' +
        this.selectedDate.getDate();

      if (serviceId !== null && empId !== null)
        this.router.navigate([
          UrlConstants.confirm_booking +
            '/' +
            serviceId +
            '/' +
            empId +
            '/' +
            date +
            '/' +
            this.selectedTimeSlotId,
        ]);
      else this.router.navigate([UrlConstants.home]);
    });
  }
}

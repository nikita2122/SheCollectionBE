import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { ServiceCategory } from 'src/app/models/services/ServiceCategory';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-make-booking',
  templateUrl: './make-booking.component.html',
  styleUrls: ['./make-booking.component.scss'],
})
export class MakeBookingComponent implements OnInit {
  category!: number;
  categories: ServiceCategory[] = [];

  constructor(
    private router: Router,
    private servicesService: ServicesService
  ) {}

  ngOnInit(): void {
    this.servicesService
      .getServiceCategories()
      .pipe(take(1))
      .subscribe((res) => {
        this.categories = res;
      });
  }

  navigate() {
    this.router.navigate([
      UrlConstants.make_booking_type + '/' + this.category,
    ]);
  }
}

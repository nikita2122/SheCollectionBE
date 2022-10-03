import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { ServiceType } from 'src/app/models/services/ServiceTypes';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-make-booking-type',
  templateUrl: './make-booking-type.component.html',
  styleUrls: ['./make-booking-type.component.scss'],
})
export class MakeBookingTypeComponent implements OnInit {
  type!: number;
  types: ServiceType[] = [];

  constructor(
    private route: ActivatedRoute,
    private servicesService: ServicesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((res) => {
      const id = res.get('categoryId');

      if (id !== null) {
        this.servicesService
          .getServiceTypes(+id)
          .pipe(take(1))
          .subscribe((res) => {
            this.types = res;
          });
      } else this.router.navigate([UrlConstants.make_bookings]);
    });
  }

  navigate() {
    this.router.navigate([UrlConstants.select_service + '/' + this.type]);
  }
}

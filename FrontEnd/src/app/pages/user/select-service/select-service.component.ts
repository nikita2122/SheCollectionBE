import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Service } from 'src/app/models/services/Service';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-select-service',
  templateUrl: './select-service.component.html',
  styleUrls: ['./select-service.component.scss'],
})
export class SelectServiceComponent implements OnInit {
  selectedServiceId!: number;
  services: Service[] = [];

  constructor(
    private servicesService: ServicesService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('typeId');

      if (id !== null) {
        this.servicesService
          .getServices(+id)
          .pipe(take(1))
          .subscribe((res) => {
            this.services = res;
          });
      } else {
        this.router.navigate([UrlConstants.make_bookings]);
      }
    });
  }

  navigate() {
    this.router.navigate([
      UrlConstants.select_staff_member + '/' + this.selectedServiceId,
    ]);
  }

  transformToTime(minutes: number) {
    const hours = Math.floor(minutes / 60);
    const minutesLeft = minutes - hours * 60;
    const hourStr = hours === 0 ? '' : hours + 'HR';
    const minutesStr =
      minutesLeft === 0 ? '' : hours === 0 ? minutesLeft + 'M' : minutesLeft;

    return hourStr + minutesStr;
  }
  select(Id: number) {
    this.selectedServiceId = Id;
    Array.from(document.getElementsByClassName('radio')).forEach(
      (element: any) => {
        if (element.id !== 'radio-' + Id) element.checked = false;
      }
    );
  }
}

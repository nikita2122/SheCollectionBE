import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Service } from 'src/app/models/services/Service';
import { ServicesService } from 'src/app/services/services.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';

@Component({
  selector: 'app-view-services',
  templateUrl: './view-services.component.html',
  styleUrls: ['./view-services.component.scss'],
})
export class ViewServicesComponent implements OnInit {
  services!: Service[];
  filteredServices!: Service[];

  constructor(
    private router: Router,
    private servicesService: ServicesService
  ) {}

  ngOnInit(): void {
    this.servicesService
      .getAllServices()
      .pipe(take(1))
      .subscribe((res) => (this.filteredServices = this.services = res));
  }

  search($event: any) {
    this.filteredServices = this.services.filter((ser) =>
      ser.serviceName.toLowerCase().includes($event.toLowerCase())
    );
  }

  addService() {
    this.router.navigate([UrlConstants.add_services + '/3']);
  }

  viewService(serviceId: number) {
    this.router.navigate([UrlConstants.view_service + '/3/' + serviceId]);
  }
}

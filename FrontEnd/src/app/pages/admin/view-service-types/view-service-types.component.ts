import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceType } from 'src/app/models/services/ServiceTypes';
import { ServicesService } from 'src/app/services/services.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';

@Component({
  selector: 'app-view-service-types',
  templateUrl: './view-service-types.component.html',
  styleUrls: ['./view-service-types.component.scss'],
})
export class ViewServiceTypesComponent implements OnInit {
  services!: ServiceType[];
  filteredServices!: ServiceType[];

  constructor(
    private router: Router,
    private servicesService: ServicesService
  ) {}

  ngOnInit(): void {
    this.servicesService
      .getAllServiceTypes()
      .pipe(take(1))
      .subscribe((res) => (this.filteredServices = this.services = res));
  }

  search($event: any) {
    this.filteredServices = this.services.filter((ser) =>
      ser.serviceTypeName.toLowerCase().includes($event.toLowerCase())
    );
  }

  addService() {
    this.router.navigate([UrlConstants.add_services + '/2']);
  }

  viewService(serviceCategoryId: number) {
    this.router.navigate([
      UrlConstants.view_service + '/2/' + serviceCategoryId,
    ]);
  }
}

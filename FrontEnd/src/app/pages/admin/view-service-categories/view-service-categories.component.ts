import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Service } from 'src/app/models/services/Service';
import { ServiceCategory } from 'src/app/models/services/ServiceCategory';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-view-service-categories',
  templateUrl: './view-service-categories.component.html',
  styleUrls: ['./view-service-categories.component.scss'],
})
export class ViewServiceCategoriesComponent implements OnInit {
  services!: ServiceCategory[];
  filteredServices!: ServiceCategory[];

  constructor(
    private router: Router,
    private servicesService: ServicesService
  ) {}

  ngOnInit(): void {
    this.servicesService
      .getServiceCategories()
      .pipe(take(1))
      .subscribe((res) => (this.filteredServices = this.services = res));
  }

  search($event: any) {
    this.filteredServices = this.services.filter((ser) =>
      ser.serviceCategoryName.toLowerCase().includes($event.toLowerCase())
    );
  }

  addService() {
    this.router.navigate([UrlConstants.add_services + '/1']);
  }

  viewService(serviceCategoryId: number) {
    this.router.navigate([
      UrlConstants.view_service + '/1/' + serviceCategoryId,
    ]);
  }
}

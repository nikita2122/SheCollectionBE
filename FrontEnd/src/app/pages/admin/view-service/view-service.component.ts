import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Service } from 'src/app/models/services/Service';
import { ServiceCategory } from 'src/app/models/services/ServiceCategory';
import { ServiceType } from 'src/app/models/services/ServiceTypes';
import { ServicesService } from 'src/app/services/services.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-service',
  templateUrl: './view-service.component.html',
  styleUrls: ['./view-service.component.scss'],
})
export class ViewServiceComponent implements OnInit {
  service!: Service;
  serviceType!: ServiceType;
  serviceCategory!: ServiceCategory;
  imgUrl: string = environment.apiUrl + 'File/download/';
  type!: number;
  id!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private servicesService: ServicesService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const type = params.get('type');
      const id = params.get('id');

      if (type !== null && id != null) {
        this.type = +type;
        this.id = +id;
        if (+type === 1) {
          this.servicesService
            .getServiceCategory(+id)
            .pipe(take(1))
            .subscribe((res) => {
              this.serviceCategory = res;
            });
        } else if (+type === 2) {
          this.servicesService
            .getServiceType(+id)
            .pipe(take(1))
            .subscribe((res) => {
              this.serviceType = res;
            });
        } else {
          this.servicesService
            .getService(+id)
            .pipe(take(1))
            .subscribe((res) => {
              this.service = res;
            });
        }
      } else {
        this.router.navigate([UrlConstants.service_management]);
      }
    });
  }

  close() {
    if (this.type === 1) {
      this.router.navigate([UrlConstants.view_services_categories]);
    } else if (this.type === 2) {
      this.router.navigate([UrlConstants.view_services_types]);
    } else {
      this.router.navigate([UrlConstants.view_services]);
    }
  }

  deleteSer() {
    if (this.type === 1) {
      this.servicesService
        .deleteServiceCategory(this.id)
        .pipe(take(1))
        .subscribe({
          next: () =>
            this.router.navigate([UrlConstants.view_services_categories]),
        });
    } else if (this.type === 2) {
      this.servicesService
        .deleteServiceType(this.id)
        .pipe(take(1))
        .subscribe({
          next: () => this.router.navigate([UrlConstants.view_services_types]),
        });
    } else {
      this.servicesService
        .deleteService(this.id)
        .pipe(take(1))
        .subscribe({
          next: () => this.router.navigate([UrlConstants.view_services]),
        });
    }
  }

  update() {
    this.router.navigate([UrlConstants.update_services + '/3/' + this.id]);
  }
}

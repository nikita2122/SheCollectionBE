import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Service } from '../models/services/Service';
import { ServiceCategory } from '../models/services/ServiceCategory';
import { ServiceRequest } from '../models/services/ServiceRequest';
import { ServiceType } from '../models/services/ServiceTypes';

@Injectable({
  providedIn: 'root',
})
export class ServicesService {
  private serviceUrl: string = environment.apiUrl + 'Services/';

  constructor(private http: HttpClient) {}

  getServiceCategories(): Observable<ServiceCategory[]> {
    return this.http.get<ServiceCategory[]>(
      this.serviceUrl + 'GetServiceCategories'
    );
  }

  getServiceCategory(id: number): Observable<ServiceCategory> {
    return this.http.get<ServiceCategory>(
      this.serviceUrl + 'GetServiceCategory',
      { params: new HttpParams().set('id', id) }
    );
  }

  getServiceType(id: number): Observable<ServiceType> {
    return this.http.get<ServiceType>(this.serviceUrl + 'GetServiceType', {
      params: new HttpParams().set('id', id),
    });
  }

  getService(id: number): Observable<Service> {
    return this.http.get<Service>(this.serviceUrl + 'GetService', {
      params: new HttpParams().set('id', id),
    });
  }

  deleteServiceCategory(id: number) {
    return this.http.get(this.serviceUrl + 'DeleteServiceCategory', {
      params: new HttpParams().set('id', id),
    });
  }

  deleteServiceType(id: number) {
    return this.http.get(this.serviceUrl + 'DeleteServiceType', {
      params: new HttpParams().set('id', id),
    });
  }

  deleteService(id: number) {
    return this.http.get(this.serviceUrl + 'DeleteService', {
      params: new HttpParams().set('id', id),
    });
  }

  createService(ser: ServiceRequest) {
    return this.http.post(this.serviceUrl + 'CreateService', ser);
  }

  getServices(typeId: number): Observable<Service[]> {
    return this.http.get<Service[]>(this.serviceUrl + 'GetServices', {
      params: new HttpParams().set('typeId', typeId),
    });
  }

  getServiceTypes(categoryId: number): Observable<ServiceType[]> {
    return this.http.get<ServiceType[]>(this.serviceUrl + 'GetServiceTypes', {
      params: new HttpParams().set('categoryId', categoryId),
    });
  }

  getAllServiceTypes(): Observable<ServiceType[]> {
    return this.http.get<ServiceType[]>(this.serviceUrl + 'GetServiceAllTypes');
  }

  getServiceById(id: number): Observable<Service> {
    return this.http.get<Service>(this.serviceUrl + 'GetServiceById', {
      params: new HttpParams().set('id', id),
    });
  }

  getAllServices(): Observable<Service[]> {
    return this.http.get<Service[]>(this.serviceUrl + 'GetAllService');
  }
}

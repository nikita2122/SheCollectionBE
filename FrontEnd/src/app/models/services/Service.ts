import { ServiceType } from './ServiceTypes';

export interface Service {
  serviceTableId: number;
  serviceName: string;
  serviceDescription: string;
  servicePicture: string;
  servicePrice: number;
  durationMin: number;
  durationMax: number;
  serviceType: ServiceType;
}

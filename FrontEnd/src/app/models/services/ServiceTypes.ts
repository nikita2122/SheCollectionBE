import { ServiceCategory } from './ServiceCategory';

export interface ServiceType {
  serviceTypeId: number;
  serviceTypeName: string;
  serviceCategory: ServiceCategory;
  imgUrl: string;
}

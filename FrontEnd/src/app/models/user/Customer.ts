import { User } from './User';

export interface Customer {
  customerEmail: string;
  customerName: string;
  customerPhoneNumber: string;
  customerSurname: string;
  customerTableId: number;
  title: any;
  user: User;
}

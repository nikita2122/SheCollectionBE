import { OrderLine } from './orderline';
import { OrderStatus } from './OrderStatus';

export interface Order {
  orderId: number;
  orderTotal: number;
  orderStatus: OrderStatus;
  orderLines: OrderLine[];
  date: Date;
}

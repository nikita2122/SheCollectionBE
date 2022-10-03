import { Service } from '../services/Service';
import { TimeSlot } from '../services/TimeSlot';
import { Customer } from '../user/Customer';
import { Schedule } from '../user/Schedule';
import { staffMember } from '../user/StaffMember';

export interface Booking {
  bookingId: number;
  bookingDescription: string;
  bookingStatus: any;
  customer: Customer;
  employee: staffMember;
  schedule: Schedule;
  timeslot: TimeSlot;
  serviceTable: Service;
}

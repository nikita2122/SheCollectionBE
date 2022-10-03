import { EmployeeType } from './EmployeeType';
import { Schedule } from './Schedule';
import { User } from './User';

export interface staffMember {
  employeeId: number;
  employeeName: string;
  employeeSurname: string;
  employeeEmail: string;
  employeeNumber: string;
  employeeType: EmployeeType;
  user: User;
  schedule: Schedule;
}

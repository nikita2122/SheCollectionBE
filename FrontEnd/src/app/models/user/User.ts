import { UserRole } from './UserRole';

export interface User {
  picture: string;
  userName: string;
  userRole: UserRole;
  userTableId: number;
}

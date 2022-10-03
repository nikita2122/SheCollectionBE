import { UserRole } from '../user/UserRole';

export interface LoginResponse {
  token: string;
  role: UserRole;
  userId: number;
}

export interface UserRole {
  userRoleId: number;
  userRoleName: string;
}

export enum UserRoleEnum {
  Admin = 1,
  Customer,
}

export const UserRoleToLabel: Record<UserRoleEnum, string> = {
  [UserRoleEnum.Admin]: 'Admin',
  [UserRoleEnum.Customer]: 'Customer',
};

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrlConstants } from './constants';
import { UserRoleEnum } from './models/user/UserRole';
import { AddProductComponent } from './pages/admin/add-product/add-product.component';
import { AddServiceComponent } from './pages/admin/add-service/add-service.component';
import { BookingManagementComponent } from './pages/admin/booking-management/booking-management.component';
import { CustomerManagementComponent } from './pages/admin/customer-management/customer-management.component';
import { EmployeeManagementComponent } from './pages/admin/employee-management/employee-management.component';
import { InventoryManagementComponent } from './pages/admin/inventory-management/inventory-management.component';
import { OrderManagementComponent } from './pages/admin/order-management/order-management.component';
import { ProductManagementComponent } from './pages/admin/product-management/product-management.component';
import { CreatePromotionComponent } from './pages/admin/promotion-management/create-promotion/create-promotion.component';
import { ReportsComponent } from './pages/admin/reports/reports.component';
import { ServiceManagementComponent } from './pages/admin/service-management/service-management.component';
import { ViewProductComponent } from './pages/admin/view-product/view-product.component';
import { ViewServiceCategoriesComponent } from './pages/admin/view-service-categories/view-service-categories.component';
import { ViewServiceTypesComponent } from './pages/admin/view-service-types/view-service-types.component';
import { ViewServiceComponent } from './pages/admin/view-service/view-service.component';
import { ViewServicesComponent } from './pages/admin/view-services/view-services.component';
import { ForgotPsswdComponent } from './pages/shared/forgot-psswd/forgot-psswd.component';
import { HomeComponent } from './pages/shared/home/home.component';
import { LoginComponent } from './pages/shared/login/login.component';
import { LogoutComponent } from './pages/shared/logout/logout.component';
import { RegisterComponent } from './pages/shared/register/register.component';
import { ResetPasswdComponent } from './pages/shared/reset-passwd/reset-passwd.component';
import { UpdatePsswdComponent } from './pages/shared/update-psswd/update-psswd.component';
import { AccountComponent } from './pages/user/account/account.component';
import { BookingsComponent } from './pages/user/bookings/bookings.component';
import { CartComponent } from './pages/user/cart/cart.component';
import { CategoriesComponent } from './pages/user/categories/categories.component';
import { ConfirmBookingComponent } from './pages/user/confirm-booking/confirm-booking.component';
import { MakeBookingTypeComponent } from './pages/user/make-booking-type/make-booking-type.component';
import { MakeBookingComponent } from './pages/user/make-booking/make-booking.component';
import { OrdersComponent } from './pages/user/orders/orders.component';
import { ProductTypesComponent } from './pages/user/product-types/product-types.component';
import { ProductsComponent } from './pages/user/products/products.component';
import { PromotionsComponent } from './pages/user/promotions/promotions.component';
import { PromotionsComponent as PromotionsManagementComponent} from './pages/admin/promotion-management/promotions/promotions.component';
import { SelectDateComponent } from './pages/user/select-date/select-date.component';
import { SelectServiceComponent } from './pages/user/select-service/select-service.component';
import { SelectStaffMemberComponent } from './pages/user/select-staff-member/select-staff-member.component';
import { ViewBookingComponent } from './pages/user/view-booking/view-booking.component';
import { ViewProductUserComponent } from './pages/user/view-product-user/view-product-user.component';
import { AuthGuardService } from './services/auth-guard.service';
import { CreateDatabaseBackupComponent } from './pages/create-database-backup/create-database-backup.component';
import { DatabaseBackupsComponent } from './pages/database-backups/database-backups.component';
import { CreateNotificationComponent } from './pages/admin/communication/create-notification/create-notification.component';
import { NotificationsComponent } from './pages/admin/communication/notifications/notifications.component';
import { UserPaymentComponent } from './pages/user/user-payment/user-payment.component';

const routes: Routes = [
  { path: UrlConstants.home, component: HomeComponent },
  {
    path: UrlConstants.products + '/:type/:productTypeId',
    component: ProductsComponent,
  },
  { path: UrlConstants.promotions, component: PromotionsComponent },
  { path: UrlConstants.bookings, component: BookingsComponent },
  { path: UrlConstants.orders, component: OrdersComponent },
  {
    path: UrlConstants.account,
    canActivate: [AuthGuardService],
    component: AccountComponent,
  },
  {
    path: UrlConstants.booking_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: BookingManagementComponent,
  },
  {
    path: UrlConstants.promotions+'/admin',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: CreatePromotionComponent,
  },
  {
    path: UrlConstants.promotions+'/admin/list',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: PromotionsManagementComponent,
  },
  {
    path: UrlConstants.customer_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: CustomerManagementComponent,
  },
  {
    path: UrlConstants.employee_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: EmployeeManagementComponent,
  },
  {
    path: UrlConstants.inventory_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: InventoryManagementComponent,
  },
  {
    path: UrlConstants.product_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: ProductManagementComponent,
  },
  {
    path: UrlConstants.add_product,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: AddProductComponent,
  },
  {
    path: UrlConstants.update_product + '/:id',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: AddProductComponent,
  },
  {
    path: UrlConstants.view_product + '/:id',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: ViewProductComponent,
  },
  {
    path: UrlConstants.categories + '/:categoryType',
    component: CategoriesComponent,
  },
  {
    path: UrlConstants.product_types + '/:type/:categoryId',
    component: ProductTypesComponent,
  },
  {
    path: UrlConstants.view_product_user + '/:productId',
    component: ViewProductUserComponent,
  },
  {
    path: UrlConstants.order_management,
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: OrderManagementComponent,
  },
  {
    path: 'admin/database',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: DatabaseBackupsComponent,
  },
  {
    path: 'pay',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: UserPaymentComponent,
  },
  {
    path: 'admin/database/create',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: CreateDatabaseBackupComponent,
  },
  {
    path: 'admin/notification/create',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: CreateNotificationComponent,
  },
  {
    path: 'admin/notification',
    canActivate: [AuthGuardService],
    data: { role: UserRoleEnum.Admin },
    component: NotificationsComponent,
  },
  {
    path: UrlConstants.cart,
    canActivate: [AuthGuardService],
    component: CartComponent,
  },
  { path: UrlConstants.login, component: LoginComponent },
  { path: UrlConstants.register, component: RegisterComponent },
  { path: UrlConstants.update_account + '/:id', component: RegisterComponent },
  {
    path: UrlConstants.update_passwd,
    component: UpdatePsswdComponent,
  },
  { path: UrlConstants.logout, component: LogoutComponent },
  { path: UrlConstants.forgot_passwd, component: ForgotPsswdComponent },
  {
    path: UrlConstants.reset_passwd + '/:email/:code',
    component: ResetPasswdComponent,
  },
  {
    path: UrlConstants.make_bookings,
    component: MakeBookingComponent,
  },
  {
    path: UrlConstants.make_booking_type + '/:categoryId',
    component: MakeBookingTypeComponent,
  },
  {
    path: UrlConstants.select_service + '/:typeId',
    component: SelectServiceComponent,
  },
  {
    path: UrlConstants.select_staff_member + '/:serviceId',
    component: SelectStaffMemberComponent,
  },
  {
    path: UrlConstants.select_date + '/:serviceId/:staffMemberId',
    component: SelectDateComponent,
  },
  {
    path:
      UrlConstants.confirm_booking +
      '/:serviceId/:staffMemberId/:date/:timeSlotId',
    component: ConfirmBookingComponent,
  },
  {
    path: UrlConstants.view_booking + '/:bookingId',
    component: ConfirmBookingComponent,
  },
  {
    path: UrlConstants.view_bookings,
    component: ViewBookingComponent,
  },
  {
    path: UrlConstants.service_management,
    component: ServiceManagementComponent,
  },

  {
    path: UrlConstants.view_services,
    component: ViewServicesComponent,
  },
  {
    path: UrlConstants.view_services_types,
    component: ViewServiceTypesComponent,
  },
  {
    path: UrlConstants.view_services_categories,
    component: ViewServiceCategoriesComponent,
  },
  {
    path: UrlConstants.add_services + '/:type',
    component: AddServiceComponent,
  },
  {
    path: UrlConstants.update_services + '/:type/:id',
    component: AddServiceComponent,
  },
  {
    path: UrlConstants.view_service + '/:type/:id',
    component: ViewServiceComponent,
  },
  {
    path: UrlConstants.reports,
    component: ReportsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

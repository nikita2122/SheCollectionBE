import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/shared/home/home.component';
import { MainNavbarComponent } from './components/main-navbar/main-navbar.component';
import { SideNavbarComponent } from './components/side-navbar/side-navbar.component';
import { BottomNavbarComponent } from './components/bottom-navbar/bottom-navbar.component';
import { BannerComponent } from './components/banner/banner.component';
import { ProductsComponent } from './pages/user/products/products.component';
import { PromotionsComponent } from './pages/user/promotions/promotions.component';
import { BookingsComponent } from './pages/user/bookings/bookings.component';
import { OrdersComponent } from './pages/user/orders/orders.component';
import { CartComponent } from './pages/user/cart/cart.component';
import { LoginComponent } from './pages/shared/login/login.component';
import { LogoutComponent } from './pages/shared/logout/logout.component';
import { BookingManagementComponent } from './pages/admin/booking-management/booking-management.component';
import { CustomerManagementComponent } from './pages/admin/customer-management/customer-management.component';
import { EmployeeManagementComponent } from './pages/admin/employee-management/employee-management.component';
import { InventoryManagementComponent } from './pages/admin/inventory-management/inventory-management.component';
import { ProductManagementComponent } from './pages/admin/product-management/product-management.component';
import { OrderManagementComponent } from './pages/admin/order-management/order-management.component';
import { AccountComponent } from './pages/user/account/account.component';
import { SearchComponent } from './components/search/search.component';
import { HttpClientModule } from '@angular/common/http';
import { AddProductComponent } from './pages/admin/add-product/add-product.component';
import { ViewProductComponent } from './pages/admin/view-product/view-product.component';
import { CategoriesComponent } from './pages/user/categories/categories.component';
import { ProductTypesComponent } from './pages/user/product-types/product-types.component';
import { ViewProductUserComponent } from './pages/user/view-product-user/view-product-user.component';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { metaReducers, reducers } from './store';
import { RegisterComponent } from './pages/shared/register/register.component';
import { UpdatePsswdComponent } from './pages/shared/update-psswd/update-psswd.component';
import { ForgotPsswdComponent } from './pages/shared/forgot-psswd/forgot-psswd.component';
import { ResetPasswdComponent } from './pages/shared/reset-passwd/reset-passwd.component';
import { MakeBookingComponent } from './pages/user/make-booking/make-booking.component';
import { ViewBookingComponent } from './pages/user/view-booking/view-booking.component';
import { MakeBookingTypeComponent } from './pages/user/make-booking-type/make-booking-type.component';
import { SelectServiceComponent } from './pages/user/select-service/select-service.component';
import { SelectStaffMemberComponent } from './pages/user/select-staff-member/select-staff-member.component';
import { SelectDateComponent } from './pages/user/select-date/select-date.component';
import { ConfirmBookingComponent } from './pages/user/confirm-booking/confirm-booking.component';
import { ServiceManagementComponent } from './pages/admin/service-management/service-management.component';
import { ViewServicesComponent } from './pages/admin/view-services/view-services.component';
import { ViewServiceCategoriesComponent } from './pages/admin/view-service-categories/view-service-categories.component';
import { ViewServiceTypesComponent } from './pages/admin/view-service-types/view-service-types.component';
import { AddServiceComponent } from './pages/admin/add-service/add-service.component';
import { ViewServiceComponent } from './pages/admin/view-service/view-service.component';
import { ReportsComponent } from './pages/admin/reports/reports.component';
import { DatabaseBackupsComponent } from './pages/database-backups/database-backups.component';
import { CreateDatabaseBackupComponent } from './pages/create-database-backup/create-database-backup.component';
import { CreatePromotionComponent } from './pages/admin/promotion-management/create-promotion/create-promotion.component';
import { CreateNotificationComponent } from './pages/admin/communication/create-notification/create-notification.component';
import { NotificationsComponent } from './pages/admin/communication/notifications/notifications.component';
import { ProcessComponent } from './pages/admin/payment/process/process.component';
import { UserPaymentComponent } from './pages/user/user-payment/user-payment.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainNavbarComponent,
    SideNavbarComponent,
    BottomNavbarComponent,
    BannerComponent,
    ProductsComponent,
    PromotionsComponent,
    BookingsComponent,
    OrdersComponent,
    CartComponent,
    LoginComponent,
    LogoutComponent,
    BookingManagementComponent,
    CustomerManagementComponent,
    EmployeeManagementComponent,
    InventoryManagementComponent,
    ProductManagementComponent,
    OrderManagementComponent,
    AccountComponent,
    SearchComponent,
    AddProductComponent,
    ViewProductComponent,
    CategoriesComponent,
    ProductTypesComponent,
    ViewProductUserComponent,
    RegisterComponent,
    UpdatePsswdComponent,
    ForgotPsswdComponent,
    ResetPasswdComponent,
    MakeBookingComponent,
    ViewBookingComponent,
    MakeBookingTypeComponent,
    SelectServiceComponent,
    SelectStaffMemberComponent,
    SelectDateComponent,
    ConfirmBookingComponent,
    ServiceManagementComponent,
    ViewServicesComponent,
    ViewServiceCategoriesComponent,
    ViewServiceTypesComponent,
    AddServiceComponent,
    ViewServiceComponent,
    ReportsComponent,
    DatabaseBackupsComponent,
    CreateDatabaseBackupComponent,
    CreatePromotionComponent,
    CreateNotificationComponent,
    NotificationsComponent,
    ProcessComponent,
    UserPaymentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

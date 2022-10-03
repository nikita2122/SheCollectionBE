import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from 'src/app/constants';
import { AuthService } from 'src/app/services/auth.service';
import { FileService } from 'src/app/services/file.service';
import { take } from 'rxjs/operators';
import { RegistrationModel } from 'src/app/models/auth/RegistrationModel';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { AuthStoreModel } from 'src/app/store/models/auth.model';
import { UserRoleEnum } from 'src/app/models/user/UserRole';
import * as authActions from 'src/app/store/actions/auth.actions';
import { CustomerService } from 'src/app/services/customer.service';
import { environment } from 'src/environments/environment';
import { UpdateAccountModel } from 'src/app/models/auth/UpdateAccountModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  file!: File;
  imgUrl!: string;
  editing: boolean = false;
  loading: boolean = true;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private fileService: FileService,
    private store: Store<AppState>,
    private customerService: CustomerService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      if (params.get('id') !== null) {
        this.editing = true;

        this.store
          .select('AuthStore')
          .pipe(take(1))
          .subscribe((store) => {
            if (store !== undefined) {
              this.customerService
                .getCustomerDetails(store.userId)
                .pipe(take(1))
                .subscribe((customer) => {
                  console.log(customer);
                  this.registerForm = this.fb.group({
                    username: [customer.user.userName, Validators.required],
                    firstname: [customer.customerName, Validators.required],
                    lastname: [customer.customerSurname, Validators.required],
                    email: [customer.customerEmail, Validators.required],
                    contact: [
                      '0' + customer.customerPhoneNumber,
                      Validators.required,
                    ],
                  });
                  if (customer.user.picture !== '') {
                    this.imgUrl =
                      environment.apiUrl +
                      'File/Download/' +
                      customer.user.picture;
                  }
                  this.loading = false;
                });
            } else {
              this.router.navigate([UrlConstants.home]);
            }
          });
      } else {
        this.registerForm = this.fb.group({
          username: ['', Validators.required],
          password: ['', Validators.required],
          firstname: ['', Validators.required],
          lastname: ['', Validators.required],
          email: ['', Validators.required],
          contact: ['', Validators.required],
        });

        this.loading = false;
      }
    });
  }

  submit() {
    if (this.editing) {
      if (this.registerForm.dirty) {
        const user: UpdateAccountModel = {
          username: this.registerForm.get('username')?.value,
          firstname: this.registerForm.get('firstname')?.value,
          lastname: this.registerForm.get('lastname')?.value,
          email: this.registerForm.get('email')?.value,
          contact: this.registerForm.get('contact')?.value.toString(),
          picture: '',
        };

        if (this.file !== undefined) {
          this.fileService
            .uploadFile(this.file)
            .pipe(take(1))
            .subscribe((res) => {
              user.picture = res.fileName;
              this.authService
                .updateAccount(user)
                .pipe(take(1))
                .subscribe({
                  next: (res) => {
                    console.log(res);

                    this.router.navigate([UrlConstants.account]);
                  },
                });
            });
        } else {
          this.authService
            .updateAccount(user)
            .pipe(take(1))
            .subscribe({
              next: (res) => {
                const authStore: AuthStoreModel = {
                  token: res.token,
                  admin: res.role.userRoleId === UserRoleEnum.Admin,
                  userId: res.userId,
                };

                this.store.dispatch(new authActions.Login(authStore));
                this.router.navigate([UrlConstants.home]);
              },
            });
        }
      }
    } else {
      const user: RegistrationModel = {
        username: this.registerForm.get('username')?.value,
        password: this.registerForm.get('password')?.value,
        firstname: this.registerForm.get('firstname')?.value,
        lastname: this.registerForm.get('lastname')?.value,
        email: this.registerForm.get('email')?.value,
        contact: this.registerForm.get('contact')?.value.toString(),
        picture: '',
      };

      if (this.file !== undefined) {
        this.fileService
          .uploadFile(this.file)
          .pipe(take(1))
          .subscribe((res) => {
            user.picture = res.fileName;
            this.authService
              .register(user)
              .pipe(take(1))
              .subscribe({
                next: (res) => {
                  const authStore: AuthStoreModel = {
                    token: res.token,
                    admin: res.role.userRoleId === UserRoleEnum.Admin,
                    userId: res.userId,
                  };

                  this.store.dispatch(new authActions.Login(authStore));
                  this.router.navigate([UrlConstants.home]);
                },
              });
          });
      } else {
        this.authService
          .register(user)
          .pipe(take(1))
          .subscribe({
            next: (res) => {
              const authStore: AuthStoreModel = {
                token: res.token,
                admin: res.role.userRoleId === UserRoleEnum.Admin,
                userId: res.userId,
              };

              this.store.dispatch(new authActions.Login(authStore));
              this.router.navigate([UrlConstants.home]);
            },
          });
      }
    }
  }

  back() {
    this.router.navigate([UrlConstants.login]);
  }
  updateFile($event: any) {
    this.file = $event.target.files[0];

    let reader = new FileReader();

    reader.readAsDataURL(this.file); // read file as data url

    reader.onload = (event: any) => {
      // called once readAsDataURL is complete
      $event.target.parentElement.parentElement.children[0].src =
        event.target.result;

      this.registerForm.markAsDirty();
    };
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginModel } from '../models/auth/LoginModel';
import { LoginResponse } from '../models/auth/LoginResponse';
import { RegistrationModel } from '../models/auth/RegistrationModel';
import { UpdateAccountModel } from '../models/auth/UpdateAccountModel';
import { updatePasswordModel } from '../models/auth/UpdatePasswordModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authUrl = environment.apiUrl + 'Auth/';

  constructor(private http: HttpClient) {}

  login(user: LoginModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.authUrl + 'Login', {
      UserName: user.UserName,
      Password: user.Password,
    });
  }

  register(user: RegistrationModel): Observable<any> {
    return this.http.post<any>(this.authUrl + 'Register', user);
  }

  updateAccount(user: UpdateAccountModel): Observable<any> {
    return this.http.post<any>(this.authUrl + 'UpdateAccount', user);
  }

  updatePassword(passwdModel: updatePasswordModel): Observable<any> {
    return this.http.post<any>(this.authUrl + 'UpdatePassword', passwdModel);
  }

  resetPassword(email: string, newPassword: string, code: string) {
    return this.http.post(this.authUrl + 'ResetPassword', {
      email,
      newPassword,
      code,
    });
  }
}

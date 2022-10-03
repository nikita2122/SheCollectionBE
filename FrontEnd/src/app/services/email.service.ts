import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmailService {
  private emailUrl = environment.apiUrl + 'Email/';

  constructor(private http: HttpClient) {}

  sendForgotPasswordEmail(email: string) {
    return this.http.get(this.emailUrl + 'SendForgotPasswordEmail', {
      params: new HttpParams().set('email', email),
    });
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { staffMember } from '../models/user/StaffMember';

@Injectable({
  providedIn: 'root',
})
export class StaffService {
  private staffUrl: string = environment.apiUrl + 'Staff/';

  constructor(private http: HttpClient) {}

  getStaffMembers(): Observable<staffMember[]> {
    return this.http.get<staffMember[]>(this.staffUrl + 'GetStaffMembers');
  }

  getStaffMemberById(id: number): Observable<staffMember> {
    return this.http.get<staffMember>(this.staffUrl + 'GetStaffMemberById', {
      params: new HttpParams().set('id', id),
    });
  }
}

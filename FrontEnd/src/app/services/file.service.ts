import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FileService {
  private fileUrl = environment.apiUrl + 'File/';

  constructor(private http: HttpClient) {}

  uploadFile(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post(this.fileUrl + 'upload', formData);
  }

  getFile(fileName: string): Observable<any> {
    return this.http.get(this.fileUrl + 'download/' + fileName);
  }

  getFileUrl(name: string) {
    return environment.apiUrl + 'File/download/' + name;
  }

  getBanners(): Observable<string[]> {
    return this.http.get<string[]>(environment.apiUrl + 'File/GetBanners');
  }
}

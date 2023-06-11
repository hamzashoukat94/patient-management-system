import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Registration } from '../interfaces/registration';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  register(registration: Registration): Observable<any> {
      return this.http.post(`${environment.accountUrl}/Registration`, registration);
  }
}

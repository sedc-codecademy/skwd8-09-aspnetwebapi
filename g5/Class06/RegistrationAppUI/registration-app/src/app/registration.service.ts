import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Registration } from './registration/registration.models';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http: HttpClient) { }

  getAllRegistrations(): Observable<Array<Registration>> {
    return this.http.get<Array<Registration>>("https://localhost:44385/api/registration");
  }
}

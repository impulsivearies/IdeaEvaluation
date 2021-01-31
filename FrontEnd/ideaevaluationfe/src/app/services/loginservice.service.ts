import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import {map } from 'rxjs/operators';
import { Judge } from '../models/judge';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private _http: HttpClient) {
   }

   login(userLogin : Login): Observable<number> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
     return this._http.post<number>('https://localhost:44380/login/userlogin', JSON.stringify(userLogin), {headers: headers}).pipe(
       map(data => {
         console.log("login API response: {0}", data);
         return data;
       }
       )
     );
   }
}

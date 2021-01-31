import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Judge } from '../models/judge';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private _http: HttpClient) { }

  getIdeasAssignedToJudge(judgeId : number) : Observable<Judge>{
    return this._http.get<Judge>('https://localhost:44380/dashboard/getdashboard/' + judgeId).pipe(
      map(
        (data) =>{
          console.log("Judge API returned: ", data);
          return data;
        }
      )
    );
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { Idea } from '../models/idea';
import { Judge } from '../models/judge';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnDestroy {

  sub: any;
  judgeId : number = -1;
  user : Judge = new Judge('','',-1,[]);
  constructor(private activatedRoute: ActivatedRoute, private dashboardService: DashboardService) { }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.sub = this.activatedRoute.paramMap.subscribe(params =>{
      this.judgeId = Number(params.get("id"));
      console.log(this.judgeId);
      this.dashboardService.getIdeasAssignedToJudge(this.judgeId).subscribe(
        data => {
          this.user = data;
        }
      );
    });
  }

  evaluate(ideaId : number){
    // Replace with call to updated isevaluated and increment count
    console.log("Idea evaluated id: ", ideaId);
    alert("Idea evaluated");
  }
}

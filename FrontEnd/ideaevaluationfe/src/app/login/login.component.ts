import { state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Judge } from '../models/judge';
import { Login } from '../models/login';  
import { LoginService } from '../services/loginservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin : Login = new Login('','');
  private loggedInUser : number = -1;
  constructor(private loginService : LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  onLogin(){
    console.log(this.userLogin.emailid + this.userLogin.password);
    this.loginService.login(this.userLogin).subscribe(data =>{
       this.loggedInUser = data;
       console.log("logged in response: ", this.loggedInUser);
       this.router.navigate(['/dashboard', this.loggedInUser]);
      });
  }
}

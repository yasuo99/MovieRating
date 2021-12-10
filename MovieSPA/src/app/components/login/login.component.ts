import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Account } from 'src/models/account';
import { Login } from 'src/models/login';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss', '../client-layout/client-layout.component.scss']
})
export class LoginComponent implements OnInit {

  username = ''
  password = ''
  constructor(private router: Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
    if(this.authService.isLoggedIn()){
      this.router.navigateByUrl("/");
    }
  }
  submit(){
    this.authService.signIn(this.username, this.password).subscribe((data) => {
      if(data.statusCode == 200){
        this.authService.setJwtToken(data.data);
        this.router.navigateByUrl("/")
      }
    })
  }
}

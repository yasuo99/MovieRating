import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {
  firstCollapsed = true;
  secondCollapsed = true;
  notificationCollapsed = true;
  userCollapsed = true;
  username: string;
  IsLoggedIn: boolean;
  constructor(private authService: AuthenticationService, private router: Router) {
    this.authService.getAccount().subscribe((account) => {
      console.log(account);
      if(!!account.id){
        this.username = account.userName!;
        this.IsLoggedIn = true;
        if(account.roles?.some(role => role === 'Admin')){
          this.router.navigateByUrl("/admin");
        }
      }
    });
    this.authService.checkLoggedIn().subscribe((loggedIn) => {
      this.IsLoggedIn = loggedIn;
    })
   }

  ngOnInit(): void {
  }
  logOut = () => {
    this.authService.signOut();
    this.router.navigateByUrl("/");
  }
}

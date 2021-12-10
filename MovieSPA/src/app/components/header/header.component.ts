import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../client-layout/client-layout.component.scss']
})
export class HeaderComponent implements OnInit {
  username = '';
  @Input() button = '';
  IsLoggedIn: boolean = false;
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
  GetData = () => {
    
  }
  LogOut = () => {
    this.authService.signOut();
  }
  test(){
    console.log("dkmm");
    
  }
}

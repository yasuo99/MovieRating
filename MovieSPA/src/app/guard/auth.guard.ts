import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/services/authentication.service';
import { JwtTokenService } from 'src/services/jwt.token.service';
@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    protected router: Router,
    private authenticationService: AuthenticationService
  ) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log(this.authenticationService.getUser());
    
    if (this.authenticationService.getUser()) {
      if (!this.authenticationService.isLoggedIn()) {
        // logged in so return true
        return true;
      }
      this.router.navigateByUrl("/login");
      return false;
    }
    // not logged in so redirect to login page
    this.router.navigateByUrl("/login");
    return false;
  }
}

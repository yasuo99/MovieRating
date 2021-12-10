import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/services/authentication.service';

@Injectable({
    providedIn: 'root'
})
export class AdminGuard implements CanActivate {
    /**
     *
     */
    constructor(private authService: AuthenticationService, private router: Router) {
        
    }
    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {
        this.authService.getAccount().subscribe(account => {
            if(!account.id){
                if(account.roles?.some(role => role === 'Admin')){
                    return true;
                }
                this.router.navigate(['/login']);
                return false;
            }
            this.router.navigate(['/login']);
            return false;
        })
        this.router.navigate(['/login']);
        return false;
    }
}

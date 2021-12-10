import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/services/authentication.service";

@Injectable()
export class HeaderInterceptor implements HttpInterceptor{
    /**
     *
     */
    constructor(private authService: AuthenticationService) {
        
    }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var token = this.authService.getJWTToken();
        req = req.clone({
            url: req.url,
            body: req.body,
            params: req.params,
            setHeaders: {
                Authorization: `Bearer ${token || ''}`
            }
        })
        return next.handle(req)
    }

}
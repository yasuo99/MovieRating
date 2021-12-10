import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError, timer } from 'rxjs';
import {
  catchError,
  delay,
  mergeMap,
  retryWhen,
  take,
  tap,
} from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
@Injectable()
export class GlobalHttpInterceptorService implements HttpInterceptor {
  retryDelay = 2000;
  retryMaxAttempts = 2;
  constructor(public router: Router, private toastService: ToastrService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      retryWhen((errors) => {
        return errors.pipe(
          mergeMap((err) => {
            if(err.status === 0)
            {
              this.toastService.error("Server sap cmnr")
              // return of(err).pipe(delay(2000), take(9));
            }
            if (err.status === 500) {
              return of(err).pipe(delay(2000), take(9));
            }
            if (err.status == 404) {
              //do something

              throw {
                error: err,
              };
            }
            if(err.status == 403){
              this.router.navigateByUrl("/login");
            }
            if(err.status == 401){
              this.toastService.warning("You are not permitted here, please contact administrator for help");
            }
            return throwError({
              error: 'Unknown error for asynchronous function:' + err,
            });
          })
        );
      })
    );
  }
}

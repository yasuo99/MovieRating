import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { retry} from "rxjs/operators";
import { Observable, timer, throwError, of } from 'rxjs';
import { retryWhen, tap, mergeMap } from 'rxjs/operators';
@Injectable()
export class RetryInterceptor implements HttpInterceptor{
    retryDelay = 2000;
    retryMaxAttempts = 2;
    constructor() { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(request)
        .pipe(
          this.retryAfterDelay(),
        );
    }
  
    retryAfterDelay(): any {
      return retryWhen(errors => {
          console.log(errors);
            
            return errors.pipe(
              mergeMap((err, count) => {
                // throw error when we've retried ${retryMaxAttempts} number of times and still get an error
                if (count === this.retryMaxAttempts) {
                  return throwError(err);
                }
                return of(err).pipe(
                  tap(error => console.log(`Retrying ${error.url}. Retry count ${count + 1}`)),
                  mergeMap(() => timer(this.retryDelay))
                );
              })
            );  
      });
     
    }
}
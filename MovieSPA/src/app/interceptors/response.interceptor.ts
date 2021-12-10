import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Injectable()
export abstract class JsonParser {
  abstract parse(text: string): any;
}
@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
  /**
   *
   */
  constructor() {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.responseType === 'json') {
      // If the expected response type is JSON then handle it here.
      console.log("Response interceptor");
      
      return next.handle(req);
    } else {
      return next.handle(req);
    }
  }
//   private handleJsonResponse(httpRequest: HttpRequest<any>, next: HttpHandler) {
//     // Override the responseType to disable the default JSON parsing.
//     httpRequest = httpRequest.clone({ responseType: 'text' });
//     // Handle the response using the custom parser.
//     return next
//       .handle(httpRequest)
//       .pipe(map((event) => this.parseJsonResponse(event)));
//   }

//   private parseJsonResponse(event: HttpEvent<any>) {
//     if (event instanceof HttpResponse && typeof event.body === 'string') {
//       return event.clone({ body: this.jsonParser.parse(event.body) });
//     } else {
//       return event;
//     }
//   }
}

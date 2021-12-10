import { Response } from './../models/response';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Home } from 'src/models/home';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HomeService {
    private baseUrl = `${environment.apiBase}/client`
    constructor(private httpClient: HttpClient) {
        
    }
    getHome(): Observable<Response<Home>>{
        return this.httpClient.get<Response<Home>>(this.baseUrl);
    }
}
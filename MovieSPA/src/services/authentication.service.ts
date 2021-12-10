import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Account } from 'src/models/account';
import { ToastrService } from 'ngx-toastr';
import { Login } from 'src/models/login';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { JwtTokenService } from './jwt.token.service';
import { Response } from 'src/models/response';
import { JWT } from 'src/models/jwt';
import { AppCookieService } from './app.cookie.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
   defaultUser: Account = {
    userName: '',
    email: '',
    phoneNumber: '',
    roles: [],
  }
  private user: Account = {
    userName: '',
    email: '',
    phoneNumber: '',
    roles: [],
  };
  baseUrl = `${environment.apiBase}/auth`;
  private account = new BehaviorSubject(this.user);
  private loggedIn = new BehaviorSubject(false);
  private jwtToken: string = '';
  private fetching: boolean = false;
  private jwtDecoded: JWT;
  /**
   *
   */
  public constructor(
    private toast: ToastrService,
    private httpClient: HttpClient,
    private jwtService: JwtTokenService,
    private cookiesService: AppCookieService
  ) {
    if(!!this.cookiesService.get("token")){
      this.jwtToken = this.cookiesService.get("token")!;
      this.jwtService.setToken(this.jwtToken);
    }
  }
  getAccount = () => {
    if (this.jwtToken) {

      this.jwtDecoded = this.jwtService.getDecodedToken()!;
      console.log(this.jwtDecoded);
      
      this.user.userName = this.jwtDecoded.unique_name;
      this.user.email = this.jwtDecoded.email;
      this.user.id = this.jwtDecoded.nameid;
      this.user.roles = this.jwtDecoded.role;
      this.cookiesService.set("token", this.jwtToken);
      this.loggedIn.next(true);
      this.account.next(this.user);
    }else{
      this.cookiesService.remove("token");
      this.loggedIn.next(false);
      this.account.next(this.defaultUser);
    }

    return this.account.asObservable();
  };
  getUser() {
    return this.jwtService.getUser();
  }
  getJWTToken() {
    return this.jwtService.getToken();
  }
  refresh(data: Account) {
    this.account.next(data);
  }
  signIn = (
    username: string,
    password: string
  ): Observable<Response<string>> => {
    let body = new Login(username, password);
    return this.httpClient.post<Response<string>>(this.baseUrl, body);
  };
  register = (username: string, password: string) => {
    this.toast.error('Error');
    return false;
  };
  signOut() {
    this.jwtToken = '';
    console.log(this.jwtToken);
    
    this.loggedIn.next(false);
    this.cookiesService.remove("token");
    this.jwtService.logOut();
    this.refresh(this.defaultUser);
  }
  setJwtToken(token: string) {
    this.jwtToken = token;
    this.jwtService.setToken(token);
  }
  isLoggedIn(): boolean {
    return !this.jwtService.isTokenExpired();
  }
  checkLoggedIn(){
    return this.loggedIn.asObservable();
  }
}

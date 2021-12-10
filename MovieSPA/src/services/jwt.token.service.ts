import { Injectable } from "@angular/core";
import jwt_decode from 'jwt-decode';
import { JWT } from "src/models/jwt";
@Injectable({
    providedIn: 'any'
})
export class JwtTokenService{
    private jwtToken: string = '';
    private decodedToken: JWT | null;
    constructor() {
        
    }
    setToken(token: string){
        if(token){
            this.jwtToken = token;
        }
    }
    decodeToken(){
        if(this.jwtToken){
            this.decodedToken = jwt_decode(this.jwtToken);
            console.log(this.decodedToken);
        }
    }
    getToken(){
        return this.jwtToken;
    }
    getDecodedToken(){
        this.decodeToken();
        return this.decodedToken;
    }
    getUser(){
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.unique_name: null;
    }
    getEmail(){
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.email : null;
    }
    getExpiryTime(){
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.exp: 0;
    }
    isTokenExpired(): boolean{
        if(!this.jwtToken){
            return true;
        }
        const expireTime: number = this.getExpiryTime();
        if(expireTime){
            return ((1000 * expireTime) - (new Date().getTime())) < 5000; 
        }
        return false;
    }
    logOut(){
        this.jwtToken = '';
        this.decodedToken = null;
    }
}

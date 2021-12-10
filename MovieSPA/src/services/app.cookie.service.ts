import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AppCookieService {
    private cookieStore:{[key: string]: string} = {}
    constructor() {
        this.parseCookies(document.cookie);
    }
    public parseCookies(cookies = document.cookie){
        this.cookieStore = {};
        if(!!cookies === false){
            return;
        }
        const cookiesArr = cookies.split(";");
        for(const cookie of cookiesArr){
            const cookieArr = cookie.split("=");
            this.cookieStore[cookieArr[0].trim()] = cookieArr[1]
        };
    }
    get(key: string){
        return !!localStorage[key] ? localStorage[key] : null;
    }
    remove(key: string){
        localStorage.removeItem(key);
    }
    set(key: string, value: string){
        localStorage.setItem(key,value);
    }
}
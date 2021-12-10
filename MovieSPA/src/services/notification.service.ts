import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { INotification } from "src/models/notifcation";

@Injectable({
    providedIn: 'root'
})
export class NotificationService{
    /**
     *
     */

    constructor(private httpClient: HttpClient) {}
    async CreateNotification(notification: INotification){
        
    }

}
interface INotificationService{
    GetAll: () => {

    }
    Getall(): void;
}
import { Injectable } from "@angular/core";
import * as signalR from '@microsoft/signalr'
@Injectable({
    providedIn: 'root'
})
export class SignalrService{
    public hubConnection = new signalR.HubConnectionBuilder().withUrl('/notification', {
        transport: signalR.HttpTransportType.WebSockets,
        accessTokenFactory: () => ""
    }).build();
    Start = () => {
        this.hubConnection.start().then(() => {
            console.log(`Connected`)
        })
    }
    Stop = () => {
        this.hubConnection.stop().then(() => {
            console.log("Disconnected")
        })
    }
}
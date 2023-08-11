import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection: any;
  private allFeed$: Subject<string> = new Subject<string>();

  public startConnection() {
    return new Promise((resolve, reject) => {
      this.hubConnection = new HubConnectionBuilder()
        .withUrl('https://localhost:7163/message')
        .build();

      this.hubConnection
        .start()
        .then(() => {
          console.log('connection established');
          return resolve(true);
        })
        .catch((err: any) => {
          console.log('error occured' + err);
          reject(err);
        });
    });
  }

  public get AllFeedObservable(): Observable<string> {
    return this.allFeed$.asObservable();
  }

  public listenToAllFeeds() {
    (<HubConnection>this.hubConnection).on('GetFeed', (data: string) => {
      this.allFeed$.next(data);
    });
  }
}

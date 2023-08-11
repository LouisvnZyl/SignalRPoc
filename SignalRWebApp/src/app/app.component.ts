import { Component } from '@angular/core';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  allFeedSubscription: any;

  constructor(private readonly signalRService: SignalrService) {
    this.signalRService.startConnection().then(() => {
      console.log('Connected');
    });

    this.signalRService.listenToAllFeeds();

    (this.allFeedSubscription = this),
      signalRService.AllFeedObservable.subscribe((data) => {
        console.log(data);
      });
  }
}

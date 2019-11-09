import { Component, Inject } from '@angular/core';
import { HttpClientStandard } from '../http-client';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClientStandard) {
    http.Get<object>('/api/Clients/search').subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class ServiceBase {

  protected readonly _httpClient : HttpClient;

  constructor(httpClient: HttpClient) {
     this._httpClient = httpClient;
   }
}


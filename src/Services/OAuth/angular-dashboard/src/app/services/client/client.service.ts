import { HttpClientStandard } from '../../http-client';
import { Observable, of } from 'rxjs';
import {
  AddOrEditClientViewModel,
  ClientViewModel,
  PageResult
  } from '../../view-models';

import {Injectable} from '@angular/core';

@Injectable()
export class ClientService  {

  private readonly _httpClient : HttpClientStandard;

  constructor(httpClient: HttpClientStandard) {
     this._httpClient = httpClient;
   }

   search(): Observable<PageResult<ClientViewModel>> {
     return this._httpClient.Get<PageResult<ClientViewModel>>('/api/Clients/search');
   }

   Create(vm: AddOrEditClientViewModel): Observable<ClientViewModel> {
     return this._httpClient.Post<ClientViewModel>('/api/Clients/search', vm);
  }
}


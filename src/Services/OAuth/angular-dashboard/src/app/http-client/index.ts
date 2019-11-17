import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
  HttpParams
 } from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';

export interface IRequestOptions {
  headers?: HttpHeaders;
  observe?: 'body';
  params?: HttpParams;
  reportProgress?: boolean;
  responseType?: 'json';
  withCredentials?: boolean;
  body?: any;
}
//https://jasonwatmore.com/post/2019/06/22/angular-8-jwt-authentication-example-tutorial
export function HttpClientStandardCreator(http: HttpClient) {
  return new HttpClientStandard(http);
}


@Injectable()
export class HttpClientStandard {

  private api = 'http://localhost:5000';

  constructor(private http: HttpClient) {
  }

  public Get<T>(endPoint: string, options?: IRequestOptions): Observable<T> {
    return this.http.get<T>(this.api + endPoint, options);
  }

  public Post<T>(endPoint: string, params: Object, options?: IRequestOptions): Observable<T> {
    return this.http.post<T>(this.api + endPoint, params, options);
  }

  public Put<T>(endPoint: string, params: Object, options?: IRequestOptions): Observable<T> {
    return this.http.put<T>(this.api + endPoint, params, options);
  }

  public Delete<T>(endPoint: string, options?: IRequestOptions): Observable<T> {
    return this.http.delete<T>(this.api + endPoint, options);
  }

}

export const HttpClientProvider = {
  provide: HttpClientStandard,
  useFactory: HttpClientStandardCreator,
  deps: [HttpClient]
}

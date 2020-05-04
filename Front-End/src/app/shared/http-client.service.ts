import {HttpClient, HttpHandler, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {map, tap} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Injectable(
    {
        providedIn: 'root'
    }
)
export class HttpClientService extends HttpClient {

    constructor(
        private httpHandler: HttpHandler,
    ) {
        super(httpHandler);
    }

    get<T>(url: string, options?: {}): Observable<T> {

        return (
            super.get<T>(url, options).pipe(
                tap((data) => {
                })
            )
        );
    }

    post<T>(url: string, body: any, options?: {}): Observable<T> {
        return super.post<T>(url, JSON.stringify(body), options);
    }

    put<T>(url: string, body: any, options?: {}): Observable<T> {
        return super.put<T>(url, JSON.stringify(body), options);
    }

    download<T>(
        url: string,
        method: string,
        body = null
    ): Observable<{ content; fileName }> {
        const headers = new HttpHeaders({'Content-Type': 'application/json'});

        let request: any;
        const options = {headers, responseType: 'blob'};
        if (method === 'POST') {
            request = this.post(url, body, options);
        } else if (method === 'GET') {
            request = this.get(url, options);
        }

        return request
            .pipe(
                map((response: any) => {
                    return {content: response, fileName: 'file'};
                })
            );
    }
}

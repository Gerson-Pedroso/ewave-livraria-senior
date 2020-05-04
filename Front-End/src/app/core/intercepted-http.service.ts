import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {finalize} from 'rxjs/operators';

@Injectable()
export class InterceptedHttp implements HttpInterceptor {

    constructor() {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (!req.headers.has('Content-Type')) {
            req = req.clone({
                headers: req.headers.set('Content-Type', 'application/json')
            });
        }
        if (!req.headers.has('Access-Control-Allow-Origin')) {
            req = req.clone({
                headers: req.headers.set('Access-Control-Allow-Origin', '*')
            });
        }

        const httpHandle = next
            .handle(req)
            .pipe(
                finalize(() => {
                })
            );
        return httpHandle;
    }
}

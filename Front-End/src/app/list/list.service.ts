import {Injectable} from '@angular/core';
import {HttpClientService} from '../shared/http-client.service';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ListService {
    urlBase = environment.api_endpoint;

    constructor(private httpService: HttpClientService) {
    }

    obterLivros() {
        const url = `${this.urlBase}/api/livros`;
        return this.httpService.get<any>(url);
    }
}

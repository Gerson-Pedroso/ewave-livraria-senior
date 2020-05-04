import {Injectable} from '@angular/core';
import {HttpClientService} from '../shared/http-client.service';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CreateService {

    urlBase = environment.api_endpoint;

    constructor(private httpService: HttpClientService) {
    }

    obterGeneros() {
        const url = `${this.urlBase}/api/genero`;
        return this.httpService.get<any>(url);
    }

    obterAutor() {
        const url = `${this.urlBase}/api/autor`;
        return this.httpService.get<any>(url);
    }

    obterEditora() {
        const url = `${this.urlBase}/api/editora`;
        return this.httpService.get<any>(url);
    }

    save(body) {
        const url = `${this.urlBase}/api/livros`;
        return this.httpService.post<any>(url, body);
    }
}

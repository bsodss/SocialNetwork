import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';

@Injectable()
export class DataService {

    private url = "https://localhost:44394/api/user";

    constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get(this.url);
    }
    getUser(id: string) {
        return this.http.get('https://localhost:44394' + this.url + '/' + id)
    }
}
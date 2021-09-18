import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable()
export class DataService {

    private url = "https://localhost:44394/api/user";

    constructor(private http: HttpClient) {
    }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.url);
    }
    getUser(id: string): Observable<User> {
        return this.http.get<User>(this.url + '/' + id);
    }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    private http: HttpClient
  ) {}

  login(username: string, password: string) {
    console.log('HELLO')
    return this.http.post('http://localhost:5000/api/account/login', {username: username, password: password}, {responseType: 'text'})
  }
}
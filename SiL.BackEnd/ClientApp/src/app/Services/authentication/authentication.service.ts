//import { BASE_PATH } from './../../APIServices/variables';
import { UserLogin } from './../../Models/login/userlogin';
import { Injectable, Optional, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private basePath = "";
  private currentUserSubject: BehaviorSubject<UserLogin>;
  public currentUser: Observable<UserLogin>;
  constructor(
    private http: HttpClient,
    //@Optional() @Inject(BASE_PATH) basePath: string
    ) {
    // if (basePath) {
    //   this.basePath = basePath;
    // }

    //取得使用者資料
    let jsonData = localStorage.getItem('currentUser') !== null ? JSON.parse(localStorage.getItem('currentUser')?.toString()!) : '';
    this.currentUserSubject = new BehaviorSubject<UserLogin>(jsonData);
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserLogin | undefined {
    return this.currentUserSubject.value;
  }

  login(account: string, password: string) {
    return this.http.post<any>(`${this.basePath}/api/account/authenticate`, { account: account, uPd: password })
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  checkAccount(account: string) {
    return this.http.post<any>(`${this.basePath}/users/check`, { account: account })
      .pipe(map(user => {
        return user;
      }));
  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('currentUser');
    let emptyUser = new UserLogin();
    this.currentUserSubject.next(emptyUser);
  }
}


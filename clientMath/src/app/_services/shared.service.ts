import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  fullName$: BehaviorSubject<string> = new BehaviorSubject<string>('');
  isLoggedIn$: BehaviorSubject<any> = new BehaviorSubject<any>('');

  setFullName(fullName: string) {
    this.fullName$.next(fullName);
  }

  setIsLoggedIn(isLoggedIn: string) {
    this.isLoggedIn$.next(isLoggedIn);
  }
}

import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  fullName$: BehaviorSubject<string> = new BehaviorSubject<string>('');
  isLoggedIn$: BehaviorSubject<any> = new BehaviorSubject<any>('');
  pickedTopic$: BehaviorSubject<string> = new BehaviorSubject<string>('');

  setFullName(fullName: string) {
    this.fullName$.next(fullName);
  }

  setIsLoggedIn(isLoggedIn: string) {
    this.isLoggedIn$.next(isLoggedIn);
  }

  setPickedTopic(pickedTopic: string) {
    this.pickedTopic$.next(pickedTopic);
  }
}

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {FormBuilder} from "@angular/forms";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  fullName$: BehaviorSubject<string> = new BehaviorSubject<string>('');
  isLoggedIn$: BehaviorSubject<any> = new BehaviorSubject<any>('');

  pickedTopic$: BehaviorSubject<string> = new BehaviorSubject<string>('init value')



  constructor() {

  }


  setFullName(fullName: string) {
    this.fullName$.next(fullName);
  }

  setIsLoggedIn(isLoggedIn: string) {
    this.isLoggedIn$.next(isLoggedIn);
  }

  updateData(topic: string): void {
    this.pickedTopic$.next(topic);
  }

}

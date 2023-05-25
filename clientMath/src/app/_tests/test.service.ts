import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor() { }

  private dataSubject1 = new Subject<number>();

  sendData(data: number) {
    this.dataSubject1.next(data);
  }

  getData() {
    return this.dataSubject1.asObservable();
  }

  // and now it should be good

  private dataSubject: BehaviorSubject<string> = new BehaviorSubject<string>('init value')
  public data$: Observable<string> = this.dataSubject.asObservable();

  updateData(newData: string): void{
    this.dataSubject.next(newData);
  }

}

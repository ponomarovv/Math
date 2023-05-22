import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResultService {
  private correctAnswersCountSubject: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  public correctAnswersCount$: Observable<number> = this.correctAnswersCountSubject.asObservable();

  constructor() { }

  getCorrectAnswersCount(): number {
    return this.correctAnswersCountSubject.value;
  }

  setCorrectAnswersCount(count: number): void {
    this.correctAnswersCountSubject.next(count);
  }
}

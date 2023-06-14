import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {QuizModel} from "../_models/q/quiz";
import {environment} from "../../environments/environment";


@Injectable({
  providedIn: 'root'
})
export class QuizService {
  private readonly baseUrl = environment.apiUrl + '/quiz';

  constructor(private http: HttpClient) {
  }

  createQuiz(quiz: QuizModel): Observable<QuizModel> {
    return this.http.post<QuizModel>(`${this.baseUrl}`, quiz);
  }

  getAllQuizzes(): Observable<QuizModel[]> {
    return this.http.get<QuizModel[]>(`${this.baseUrl}`);
  }

  getQuizById(id: number): Observable<QuizModel> {
    return this.http.get<QuizModel>(`${this.baseUrl}/${id}`);
  }

  updateQuiz(id: number, quiz: QuizModel): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, quiz);
  }

  deleteQuiz(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

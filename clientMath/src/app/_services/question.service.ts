import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {QuestionModel} from "../_models/q/question";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  // private readonly baseUrl = 'api/questions';
  private readonly baseUrl = environment.apiUrl + '/Question';

  constructor(private http: HttpClient) {
  }

  getQuestions(): Observable<QuestionModel[]> {
    return this.http.get<QuestionModel[]>(this.baseUrl+'/random');
  }

  getQuestionById(id: number): Observable<QuestionModel> {
    return this.http.get<QuestionModel>(`${this.baseUrl}/${id}`);
  }



  addQuestion(question: QuestionModel): Observable<QuestionModel> {
    return this.http.post<QuestionModel>(this.baseUrl, question);
  }

  updateQuestion(question: QuestionModel): Observable<QuestionModel> {
    return this.http.put<QuestionModel>(`${this.baseUrl}/${question.id}`, question);
  }

  deleteQuestion(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}

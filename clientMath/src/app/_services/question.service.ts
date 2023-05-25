import {Injectable, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {QuestionModel} from "../_models/q/question";
import {environment} from "../../environments/environment";
import {SharedService} from "./shared.service";

@Injectable({
  providedIn: 'root'
})
export class QuestionService implements OnInit{

  // private readonly baseUrl = 'api/questions';
  private readonly baseUrl = environment.apiUrl + '/Question';

  pickedTopic: string = '';

  constructor(private http: HttpClient, private sharedService: SharedService) {
  }

  ngOnInit(): void {
      this.sharedService.pickedTopic$.subscribe((newData: string) => {
      this.pickedTopic = newData;
    });
  }

  getQuestions(): Observable<QuestionModel[]> {
    return this.http.get<QuestionModel[]>(this.baseUrl + '/Random');
  }

  getQuestionsByTopic(topic: string): Observable<QuestionModel[]> {
    console.log(topic);
    return this.http.get<QuestionModel[]>(this.baseUrl + '/' + 'Random');
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

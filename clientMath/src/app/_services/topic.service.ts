import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {SharedService} from "./shared.service";
import {Observable} from "rxjs";
import {TopicModel} from "../_models/q/topic";

@Injectable({
  providedIn: 'root'
})
export class TopicService {
  private readonly baseUrl = environment.apiUrl + '/Topic';

  pickedTopic: string = '';

  constructor(private http: HttpClient, private sharedService: SharedService) {
  }

  getTopics(): Observable<TopicModel[]> {
    console.log(this.baseUrl);
    let result = this.http.get<TopicModel[]>(this.baseUrl);
    return result;
  }

  getTopicByTopicText(text: string): Observable<TopicModel> {
    console.log(this.baseUrl + '/' + text);
    let result = this.http.get<TopicModel>(this.baseUrl + '/' + text);
    return result;
  }

}

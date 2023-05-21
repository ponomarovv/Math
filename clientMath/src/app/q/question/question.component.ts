import {Component, OnInit} from '@angular/core';
import {QuestionModel} from "../../_models/q/question";
import {QuestionService} from "../../_services/question.service";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})

export class QuestionComponent implements OnInit {

  question: QuestionModel | null = null;

  constructor(private questionService: QuestionService) {
  }

  ngOnInit(): void {
    this.getQuestion(1);
  }

  getQuestion(id: number) {
    this.questionService.getQuestionById(id)
      .subscribe(
        (question: QuestionModel) => {
          this.question = question;
        },
        (error: any) => {
          console.error(error);
        }
      );
  }
}

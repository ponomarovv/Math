import { Component } from '@angular/core';
import {QuestionModel} from "../../_models/q/question";
import {QuestionService} from "../../_services/question.service";

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {


  questions: QuestionModel[] | null = null;

  constructor(private questionService: QuestionService) {
  }

  ngOnInit(): void {
    this.getQuestions();
  }

  getQuestions() {
    this.questionService.getQuestions()
      .subscribe(
        (questions: QuestionModel[]) => {
          this.questions = questions;
        },
        (error: any) => {
          console.error(error);
        }
      );
  }
}

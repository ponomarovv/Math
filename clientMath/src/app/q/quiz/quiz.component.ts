import { Component } from '@angular/core';
import {QuestionModel} from "../../_models/q/question";
import {QuestionService} from "../../_services/question.service";
import {AnswerModel} from "../../_models/q/answer";
import {Router} from "@angular/router";

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {

  questions: QuestionModel[] | null = null;
  correctAnswersCount: number = 0;

  constructor(private questionService: QuestionService, private router: Router) {
  }

  ngOnInit(): void {
    this.getQuestions();
  }

  getQuestions() {
    this.questionService.getQuestions()
      .subscribe(
        (questions: QuestionModel[]) => {
          this.questions = questions;
          this.resetAnswersCount();
        },
        (error: any) => {
          console.error(error);
        }
      );
  }

  checkAnswer(question: QuestionModel, selectedAnswer: AnswerModel) {
    // Mark the question as answered
    question.answered = true;
    question.answeredAnswer = selectedAnswer;
    // Increment the correct answers count if the selected answer is correct
    if (selectedAnswer.isCorrect) {
      this.correctAnswersCount++;
    }
  }

  showResults() {
    this.router.navigateByUrl('/result', { state: { correctAnswersCount: this.correctAnswersCount } });
  }

  resetAnswersCount() {
    this.correctAnswersCount = 0;
  }

  hasUnansweredQuestions(): boolean {
    if (this.questions) {
      return this.questions.some(question => !question.answered);
    }
    return false;
  }
}

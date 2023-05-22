import {Component} from '@angular/core';
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

  showQuestions: boolean = true;
  dictionary: { [key: string]: number } = {};

  maxKeys: string[] = [];

  constructor(private questionService: QuestionService, private router: Router) {
  }

  ngOnInit(): void {
    this.showQuestions = true;
    this.getQuestions();
    this.dictionary = {};

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
    } else {
      // Add the question topic to the wrong answer topics list
      const topic = question.topicModel?.text;
      if (topic !== null && topic !== undefined) {
        if (topic && this.dictionary.hasOwnProperty(topic)) {
          this.dictionary[topic] += 1;
        } else {
          this.dictionary[topic] = 1;
        }
      }
    }
  }


  showResults() {
    this.showQuestions = false;

    let maxCount = 0;


    for (const key in this.dictionary) {
      const value = this.dictionary[key];
      if (value > maxCount) {
        maxCount = value;
      }
    }
    for (const key in this.dictionary) {
      if (this.dictionary[key] == maxCount) {
        this.maxKeys.push(key);
      }
    }
    this.maxKeys.sort();
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

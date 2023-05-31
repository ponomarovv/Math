import {Component} from '@angular/core';
import {QuestionModel} from "../../_models/q/question";
import {QuestionService} from "../../_services/question.service";
import {AnswerModel} from "../../_models/q/answer";
import {Router} from "@angular/router";
import {SharedService} from "../../_services/shared.service";
import {TopicModel} from "../../_models/q/topic";
import {LoginComponent} from "../../user/login/login.component";

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {

  questions: QuestionModel[] | null = null;
  correctAnswersCount: number = 0;
  wrongAnswersCount: number = 0;

  isLoadingQuestions: boolean = true;
  showQuestions: boolean = true;
  dictionary: { [key: string]: number } = {};

  maxKeys: string[] = [];

  pickedTopic: string = '';

  showingResults: boolean = false;

  topicsInThisQuiz: TopicModel [] = [];
  topicNamesInThisQuiz: string [] = [];
  topicsToShowInResultOfThisQuiz: TopicModel [] = [];


  constructor(private questionService: QuestionService,
              private router: Router,
              private sharedService: SharedService) {
  }

  ngOnInit(): void {
    console.log('quiz component on init')

    this.sharedService.pickedTopic$.subscribe((topic: string) => {
      this.pickedTopic = topic;
    });

    this.dictionary = {};
    this.getQuiz();
  }

  getQuiz() {
    console.log('getQuiz');
    if (this.pickedTopic == '') return;
    this.questionService.getQuestionsByTopic(this.pickedTopic)
      .subscribe(
        (questions: QuestionModel[]) => {
          this.questions = questions;
          this.resetAnswersCount();
          this.isLoadingQuestions = false;
        },
        (error: any) => {
          console.error(error);
        }
      );
  };

  checkAnswer(question: QuestionModel, selectedAnswer: AnswerModel) {
    if (!this.showingResults) {
      // Mark the question as answered
      question.answered = true;
      question.answeredAnswer = selectedAnswer;
      // console.log(question.topicModel?.text);

      if (!this.topicNamesInThisQuiz.includes(question.topicModel?.text!)) {
        // console.log('hi');
        // console.log(question.topicModel?.text);
        this.topicNamesInThisQuiz.push(question.topicModel?.text!);
        this.topicsInThisQuiz.push(question.topicModel!);
      }


      // Increment the correct or wrong answers count based on the selected answer

      // if (selectedAnswer.isCorrect) {
      //   this.correctAnswersCount++;
      // } else {
      //   this.wrongAnswersCount++;
      //   // Add the question topic to the wrong answer topics list
      //   const topic = question.topicModel?.text;
      //   if (topic) {
      //     if (this.dictionary.hasOwnProperty(topic)) {
      //       this.dictionary[topic] += 1;
      //     } else {
      //       this.dictionary[topic] = 1;
      //     }
      //   }
      // }

    }
  }

  showResults() {
    console.log(this.topicsInThisQuiz);

    this.showQuestions = false;
    this.showingResults = true;
    this.resetAnswersCount();

    if (this.questions) {
      for (const question of this.questions) {
        if (!question.answered) continue;
        const selectedAnswer = question.answeredAnswer;
        if (selectedAnswer?.isCorrect) {
          this.correctAnswersCount++;
        } else {
          this.wrongAnswersCount++;
          // Add the question topic to the wrong answer topics list
          const topic = question.topicModel?.text;
          if (topic) {
            if (this.dictionary.hasOwnProperty(topic)) {
              this.dictionary[topic] += 1;
            } else {
              this.dictionary[topic] = 1;
            }
          }
        }
      }
    }

    let maxCount = 0;
    for (const key in this.dictionary) {
      const value = this.dictionary[key];
      if (value > maxCount) {
        maxCount = value;
      }
    }


    for (const key in this.dictionary) {
      if (this.dictionary[key] == maxCount) {
        this.maxKeys?.push(key);
      }
    }
    this.maxKeys?.sort();

    for (const topic of this.maxKeys) {
      for (const topicElement of this.topicsInThisQuiz) {
        if (topicElement.text == topic) {
          this.topicsToShowInResultOfThisQuiz.push(topicElement);
        }
      }
    }

    console.log(this.topicsToShowInResultOfThisQuiz);
  }

  resetAnswersCount() {
    this.correctAnswersCount = 0;
    this.wrongAnswersCount = 0;
    this.maxKeys = [];
  }

  hasUnansweredQuestions(): boolean {
    if (this.questions) {
      return this.questions.some(question => !question.answered);
    }
    return false;
  }
}

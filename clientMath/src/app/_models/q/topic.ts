import {QuestionModel} from "./question";
import {BookModel} from "./book";

export class TopicModel {
  id: number | null = null;
  text: string | null = null;
  questionModels: QuestionModel[] | null = null;
  bookModels: BookModel[] | null = null;

  constructor(text: string) {
    this.text = text;
  }
}

import {QuestionModel} from "./question";

export class TopicModel {
  id: number | null = null;
  text: string | null = null;
  questions: QuestionModel[] | null = null;
}

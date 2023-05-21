import {QuestionModel} from "./question";

export class TopicModel {
  id: number | null = null;
  text: string | null = null;
  questionModels: QuestionModel[] | null = null;
}

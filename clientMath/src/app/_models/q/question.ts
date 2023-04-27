import {TopicModel} from "./topic";
import {AnswerModel} from "./answer";

export class QuestionModel {
  id: number | null = null;
  text: string | null = null;
  topic: TopicModel | null = null;
  answer: AnswerModel[] | null = null;
}

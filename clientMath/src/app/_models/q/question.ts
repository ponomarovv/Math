import {TopicModel} from "./topic";
import {AnswerModel} from "./answer";

export class QuestionModel {
  id: number | null = null;
  text: string | null = null;
  topicModel: TopicModel | null = null;
  answerModels: AnswerModel[] | null = null;
  answered: any = null;
  answeredAnswer: any  = null;

}

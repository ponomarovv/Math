import {QuizModel} from "./quiz";
import {TopicModel} from "./topic";

export class TopicForQuizModel {
  id: number | null = null;
  QuizModel: QuizModel | null = null;
  TopicModel: TopicModel | null = null;
}

import {TopicModel} from "./topic";

export class QuizModel {
  id: number | null = null;
  quizDate: any;
  applicationUser: any | null = null;

  mainTopicId: number | null = null;
  mainTopicText: string | null = null;
  topics: TopicModel[] | null = null;
}

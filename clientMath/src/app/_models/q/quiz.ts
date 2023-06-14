import {TopicModel} from "./topic";
import {UserModel} from "../user";

export class QuizModel {
  id: number | null = null;
  quizDate: any;
  applicationUser: UserModel | null = null;

  MainTopic: TopicModel | null = null;
  topicQuizzes: TopicModel[] | null = null;
}

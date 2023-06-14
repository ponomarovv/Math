import {TopicModel} from "./topic";
import {UserModel} from "../user";

export class QuizModel {
  id: number | null = null;
  quizDate: any;
  applicationUser: UserModel | null = null;

  mainTopic: TopicModel | null = null;
  topicQuizzes: TopicModel[] | null = null;
}

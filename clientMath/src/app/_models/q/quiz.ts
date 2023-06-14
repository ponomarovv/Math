import {TopicModel} from "./topic";
import {UserModel} from "../user";

export class QuizModel {
  id: number | null = null;
  quizDate: any;
  applicationUser: UserModel | null = null;

  mainTopicId: number | null = null;
  mainTopicText: string | null = null;
  topicQuizzes: TopicModel[] | null = null;
}

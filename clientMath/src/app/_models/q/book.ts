import {TopicModel} from "./topic";

export class BookModel {
  id: number | null = null;
  text: string | null = null;
  topicModel: TopicModel[] | null = null;
}

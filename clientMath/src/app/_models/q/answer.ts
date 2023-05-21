import {QuestionModel} from "./question";

export class AnswerModel {
  id: number | null = null;
  text: string | null = null;
  isCorrect: boolean | null = null;
  questionModel: QuestionModel | null = null;
}

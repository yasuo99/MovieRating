export interface IResponse<T> {
  data: T;
  error: boolean;
  statusCode: number;
  message: string;
}
export class Response<T> implements IResponse<T> {
  data: T;
  error: boolean;
  statusCode: number;
  message: string;
  /**
   *
   */
  constructor() {}
  /**
   *
   */
}

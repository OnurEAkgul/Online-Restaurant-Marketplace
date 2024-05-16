export interface GenericResponseModel<T> {
  data: T;
  success: boolean;
  message: string;
}

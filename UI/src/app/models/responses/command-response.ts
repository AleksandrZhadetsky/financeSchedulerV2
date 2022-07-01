export class CommandResponse<T> {
  constructor(
    public responseModel: T,
    public responseMessage: string
  ) {}
}

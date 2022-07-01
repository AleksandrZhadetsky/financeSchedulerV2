export class PurchaseCreationModel {
  constructor(
    public name: string,
    public cost: number,
    public count: number,
    public categoryId: string,
    public createdById: string
  ) {}
}

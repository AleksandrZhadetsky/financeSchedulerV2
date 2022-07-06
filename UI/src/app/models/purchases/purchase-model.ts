import { CategoryModel } from "../categories/category-model";

export class PurchaseModel {
  constructor(
    public id: string,
    public name: string,
    public cost: number,
    public count: number,
    public categoryId: string,
    public category: CategoryModel,
    public creationDate: Date
  ) {}
}

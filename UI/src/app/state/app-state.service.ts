import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { CategoryModel } from "../models/categories/category-model";
import { PurchaseModel } from "../models/purchases/purchase-model";

@Injectable({
  providedIn: "root",
})
export class AppStateService {
  public readonly purchases = new BehaviorSubject<PurchaseModel[]>([]);
  public readonly categories = new BehaviorSubject<CategoryModel[]>([]);

  public readonly purchases$ = this.purchases.asObservable();
  public readonly categories$ = this.categories.asObservable();

  constructor() {}
}

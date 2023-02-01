import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { CategoryModel } from "../models/categories/category-model";
import { IdentityUser } from "../models/identity/user/identityUser";
import { PurchaseModel } from "../models/purchases/purchase-model";

@Injectable({
  providedIn: "root",
})
export class AppStateService {
  public readonly purchases = new BehaviorSubject<PurchaseModel[]>([]);
  public readonly categories = new BehaviorSubject<CategoryModel[]>([]);
  public readonly user = new BehaviorSubject<IdentityUser>({} as any);

  public readonly purchases$ = this.purchases.asObservable();
  public readonly categories$ = this.categories.asObservable();
  public readonly user$ = this.user.asObservable();

  constructor() {}
}

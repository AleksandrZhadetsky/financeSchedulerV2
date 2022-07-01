import { Component, OnInit } from "@angular/core";
import { CategoryModel } from "src/app/models/categories/category-model";
import { PurchaseCreationModel } from "src/app/models/purchases/purchase-creation-model";
import { CategoryManagementService } from "src/app/services/category-management/category-management.service";
import { IdentityService } from "src/app/services/identity/identity.service";
import { PurchaseManagementService } from "src/app/services/purchase-management/purchase-management.service";
import { AppStateService } from "src/app/state/app-state.service";

@Component({
  selector: "app-create-purchase",
  templateUrl: "./create-purchase.component.html",
  styleUrls: ["./create-purchase.component.scss"],
})
export class CreatePurchaseComponent implements OnInit {
  private createdById!: string;

  public categories!: CategoryModel[];
  public submitBtnDisabled!: boolean;
  public purchaseName!: string;
  public purchaseCost!: number;
  public itemsCount!: number;
  public categoryId!: string;

  constructor(
    private service: PurchaseManagementService,
    private categoryService: CategoryManagementService,
    private store: AppStateService,
    private identityService: IdentityService
  ) {}

  ngOnInit(): void {
    this.createdById = this.identityService.userValue.id;
    this.categories = this.store.categories;
    if (!this.categories || !this.categories.length) {
      this.categoryService.getCategories()
        .subscribe(categories => {
          this.categories = categories.responseModel;
          this.store.categories = categories.responseModel;
        });
    }
  }

  public onPurchaseCreationTriggered(): void {
    this.service
      .registerPurchase(
        new PurchaseCreationModel(
          this.purchaseName,
          this.purchaseCost,
          this.itemsCount,
          this.categoryId,
          this.createdById
        )
      )
      .subscribe();
  }
}

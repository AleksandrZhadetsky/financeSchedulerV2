import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { CategoryModel } from "src/app/models/categories/category-model";
import { PurchaseCreationModel } from "src/app/models/purchases/purchase-creation-model";

@Component({
  selector: "app-create-purchase",
  templateUrl: "./create-purchase.component.html",
  styleUrls: ["./create-purchase.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreatePurchaseComponent {
  @Input() categories!: CategoryModel[];

  @Output() purchaseCreated = new EventEmitter<PurchaseCreationModel>();

  public submitBtnDisabled!: boolean;
  public purchaseName!: string;
  public purchaseCost!: number;
  public itemsCount!: number;
  public categoryId!: string;

  constructor() {}

  public onPurchaseCreationTriggered(): void {
    this.purchaseCreated.emit({
      name: this.purchaseName,
      cost: this.purchaseCost,
      count: this.itemsCount,
      categoryId: this.categoryId,
      createdById: ''
    });
  }
}

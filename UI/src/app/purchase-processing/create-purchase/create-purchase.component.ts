import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { CategoryModel } from "../../models/categories/category-model";
import { PurchaseCreationModel } from "../../models/purchases/purchase-creation-model";
import { AppStateService } from "../../state/app-state.service";

@Component({
  selector: "app-create-purchase",
  templateUrl: "./create-purchase.component.html",
  styleUrls: ["./create-purchase.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreatePurchaseComponent {
  @Input() categories$!: Observable<CategoryModel[]>;

  @Output() purchaseCreated = new EventEmitter<PurchaseCreationModel>();

  public submitBtnDisabled!: boolean;
  public purchaseName!: string;
  public purchaseCost!: number;
  public itemsCount!: number;
  public categoryId!: string;

  constructor(private cdr: ChangeDetectorRef, private stateService: AppStateService) {}

  public onPurchaseCreation(): void {
    this.purchaseCreated.emit({
      name: this.purchaseName,
      cost: this.purchaseCost,
      count: this.itemsCount,
      categoryId: this.categoryId,
      createdById: this.stateService.user.value.id
    });
  }
}

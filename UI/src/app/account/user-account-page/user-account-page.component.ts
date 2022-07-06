import { Component, OnInit, ViewChild } from "@angular/core";
import { MatAccordion } from "@angular/material/expansion";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Observable } from "rxjs";
import { CategoryCreationModel } from "src/app/models/categories/category-creation-model";
import { CategoryModel } from "src/app/models/categories/category-model";
import { PurchaseCreationModel } from "src/app/models/purchases/purchase-creation-model";
import { PurchaseModel } from "src/app/models/purchases/purchase-model";
import { CategoryManagementService } from "src/app/services/category-management/category-management.service";
import { PurchaseManagementService } from "src/app/services/purchase-management/purchase-management.service";
import { AppStateService } from "src/app/state/app-state.service";
import { IdentityUser } from "../../models/identity/user/identityUser";
import { IdentityService } from "../../services/identity/identity.service";

@Component({
  templateUrl: "./user-account-page.component.html",
  styleUrls: ["./user-account-page.component.scss"],
})
export class UserAccountPageComponent implements OnInit {
  @ViewChild(MatAccordion) accordion!: MatAccordion;

  private createdById!: string;

  public readonly user: IdentityUser;
  public panelOpenState = false;
  public categories$!: Observable<CategoryModel[]>;
  public purchases$!: Observable<PurchaseModel[]>;

  constructor(
    private identityService: IdentityService,
    private purchaseService: PurchaseManagementService,
    private categoryService: CategoryManagementService,
    private store: AppStateService,
    private snackBar: MatSnackBar
  ) {
    this.user = identityService.userValue;
  }

  public ngOnInit(): void {
    this.createdById = this.identityService.userValue.id;
    this.categories$ = this.store.categories$;
    if (!this.store.categories.value.length) {
      this.categoryService.getCategories()
        .subscribe(categories => {
          this.store.categories.next(categories.responseModel);
        });
    }

    this.purchases$ = this.store.purchases$;
    if (!this.store.purchases.value.length) {
      this.purchaseService.getPurchases()
        .subscribe(purchases => {
          this.store.purchases.next(purchases.responseModel);
        });
    }
  }

  public onPurchaseCreationStarted(event: PurchaseCreationModel): void {
    this.purchaseService
      .createPurchase(
        new PurchaseCreationModel(
          event.name,
          event.cost,
          event.count,
          event.categoryId,
          this.createdById
        )
      )
      .subscribe();

    this.accordion.closeAll();
    this.openSnackBar('Purchase created.', 'Ok')
  }

  public onCategoryCreationStarted(event: CategoryCreationModel): void {
    this.categoryService
      .createCategory(
        new CategoryCreationModel(
          event.name,
          event.description
        )
      )
      .subscribe();

    this.accordion.closeAll();
    this.openSnackBar('Category created.', 'Ok')
  }

  private openSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action);
  }
}

import { Component, OnInit, ViewChild } from "@angular/core";
import { MatAccordion } from "@angular/material/expansion";
import { MatSnackBar } from "@angular/material/snack-bar";
import { IdentityUser } from "../../models/identity/user/identityUser";
import { IdentityService } from "../../services/identity/identity.service";

@Component({
  templateUrl: "./user-account-page.component.html",
  styleUrls: ["./user-account-page.component.scss"],
})
export class UserAccountPageComponent {
  @ViewChild(MatAccordion) accordion!: MatAccordion;

  public readonly user: IdentityUser;
  public panelOpenState = false;

  constructor(private identityService: IdentityService, private snackBar: MatSnackBar) {
    this.user = identityService.userValue;
  }

  public onPurchaseCreated(): void {
    this.accordion.closeAll();
    this.openSnackBar('Purchase created.', 'Ok')
  }

  public onCategoryCreated(): void {
    this.accordion.closeAll();
    this.openSnackBar('Category created.', 'Ok')
  }

  public openSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action);
  }
}

import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserAccountPageComponent } from "./user-account-page/user-account-page.component";
import { MatCardModule } from "@angular/material/card";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatExpansionModule } from "@angular/material/expansion";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "../home/home.component";
import { AuthGuard } from "../services/identity/auth-guard/auth-guard";
import { PurchasesModule } from "../purchase-processing/purchases.module";
import { CategoriesModule } from "../category-processing/categories.module";

@NgModule({
  declarations: [UserAccountPageComponent],
  imports: [
    CommonModule,
    PurchasesModule,
    CategoriesModule,
    MatSnackBarModule,
    MatCardModule,
    MatExpansionModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: 'account/:id', component: UserAccountPageComponent, canActivate: [AuthGuard] },
    ]),
  ],
})
export class AccountModule {}

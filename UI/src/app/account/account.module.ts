import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserAccountPageComponent } from "./user-account-page/user-account-page.component";
import { PurchasesModule } from "../purchase-management/purchases.module";
import { MatCardModule } from "@angular/material/card";
import { MatExpansionModule } from "@angular/material/expansion";
import { CategoriesModule } from "../category-management/categories.module";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "../home/home.component";
import { AuthGuard } from "../services/identity/auth-guard/auth-guard";

@NgModule({
  declarations: [UserAccountPageComponent],
  imports: [
    CommonModule,
    PurchasesModule,
    CategoriesModule,
    MatCardModule,
    MatExpansionModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: 'account/:id', component: UserAccountPageComponent, canActivate: [AuthGuard] },
    ]),
  ],
})
export class AccountModule {}

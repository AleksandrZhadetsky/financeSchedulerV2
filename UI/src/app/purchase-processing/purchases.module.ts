import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CreatePurchaseComponent } from "./create-purchase/create-purchase.component";
import { PurchaseListComponent } from "./purchase-list/purchase-list.component";
import { FormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTableModule } from "@angular/material/table";
import { MatSelectModule } from "@angular/material/select";

@NgModule({
  declarations: [CreatePurchaseComponent, PurchaseListComponent],
  exports: [CreatePurchaseComponent, PurchaseListComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatTableModule,
    MatInputModule,
    MatSelectModule,
  ],
})
export class PurchasesModule {}

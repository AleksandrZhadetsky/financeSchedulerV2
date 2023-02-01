import { ChangeDetectionStrategy, Component, EventEmitter, Output } from "@angular/core";
import { CategoryCreationModel } from "../../models/categories/category-creation-model";

@Component({
  selector: "app-create-category",
  templateUrl: "./create-category.component.html",
  styleUrls: ["./create-category.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateCategoryComponent {
  @Output() categoryCreationStarted = new  EventEmitter<CategoryCreationModel>();

  public categoryName = "";
  public categoryDescription = "";

  constructor() {}

  public onCategoryCreationTriggered(): void {
    this.categoryCreationStarted.emit({
      name: this.categoryName,
      description: this.categoryDescription
    });
  }
}

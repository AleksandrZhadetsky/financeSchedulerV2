import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { CategoryCreationModel } from "src/app/models/categories/category-creation-model";
import { CategoryManagementService } from "src/app/services/category-management/category-management.service";

@Component({
  selector: "app-create-category",
  templateUrl: "./create-category.component.html",
  styleUrls: ["./create-category.component.scss"],
})
export class CreateCategoryComponent implements OnInit {
  @Output() categoryCreated = new  EventEmitter();

  public categoryName = "";
  public categoryDescription = "";

  constructor(
    private service: CategoryManagementService
  ) {}

  ngOnInit(): void {}

  public onCategoryCreationTriggered(): void {
    this.service
      .createCategory(
        new CategoryCreationModel(this.categoryName, this.categoryDescription)
      )
      .subscribe(
        () => {
          this.categoryCreated.emit('category created');
        }
      );
  }
}

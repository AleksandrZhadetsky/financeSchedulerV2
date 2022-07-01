import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { CategoryCreationModel } from "src/app/models/categories/category-creation-model";
import { CategoryModel } from "src/app/models/categories/category-model";
import { CommandResponse } from "src/app/models/responses/command-response";
import { DeleteCommand } from "src/app/models/commands/delete-command";
import { AppStateService } from "src/app/state/app-state.service";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class CategoryManagementService {
  private readonly controller = "categories";
  private readonly createAction = "create";
  private readonly getAllAction = "getAll";
  private readonly getOneAction = "get";
  private readonly deleteAction = "delete";

  constructor(private httpClient: HttpClient, private store: AppStateService) {}

  public registerCategory(
    category: CategoryCreationModel
  ): Observable<CommandResponse<CategoryModel>> {
    return this.httpClient
      .post<CommandResponse<CategoryModel>>(
        `${environment.apiUrl}/${this.controller}/${this.createAction}`,
        category
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.categories.push(response.responseModel);
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public getCategories(): Observable<CommandResponse<CategoryModel[]>> {
    return this.httpClient
      .get<CommandResponse<CategoryModel[]>>(
        `${environment.apiUrl}/${this.controller}/${this.getAllAction}`
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.categories.concat(response.responseModel);
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  // public getCategory(
  //   category: CategoryCreationModel
  // ): Observable<CommandResponse> {
  //   return null as any;
  //   // return this.httpClient
  //   // .get<CommandResponse>(
  //   //   `${'https://localhost:5001'}/${this.controller}/${this.getAllAction}`)
  // }

  public deleteCategory(id: string): Observable<CommandResponse<null>> {
    return this.httpClient
      .post<CommandResponse<null>>(
        `${'https://localhost:5001'}/${this.controller}/${this.deleteAction}`,
        new DeleteCommand(id)
      )
      .pipe(
        tap((response) => {}),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }
}

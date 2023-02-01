import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { environment } from "../../../environments/environment";
import { CategoryCreationModel } from "../../models/categories/category-creation-model";
import { CategoryModel } from "../../models/categories/category-model";
import { DeleteCommand } from "../../models/commands/delete-command";
import { CommandResponse } from "../../models/responses/command-response";
import { AppStateService } from "../../state/app-state.service";

@Injectable({
  providedIn: "root",
})
export class CategoryProcessingService {
  private readonly controller = "categories";
  private readonly createAction = "create";
  private readonly getAllAction = "getAll";
  private readonly getOneAction = "get";
  private readonly deleteAction = "delete";

  constructor(private httpClient: HttpClient, private store: AppStateService) {}

  public createCategory(
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
            this.store.categories.next([...this.store.categories.value, response.responseModel]);
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
            this.store.categories.next(response.responseModel);
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

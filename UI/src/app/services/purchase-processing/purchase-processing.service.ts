import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { environment } from "../../../environments/environment";
import { DeleteCommand } from "../../models/commands/delete-command";
import { PurchaseCreationModel } from "../../models/purchases/purchase-creation-model";
import { PurchaseModel } from "../../models/purchases/purchase-model";
import { CommandResponse } from "../../models/responses/command-response";
import { AppStateService } from "../../state/app-state.service";

@Injectable({
  providedIn: "root",
})
export class PurchaseProcessingService {
  private readonly controller = "purchases";
  private readonly createAction = "create";
  private readonly getAllAction = "getAll";
  private readonly deleteAction = "delete";

  constructor(private httpClient: HttpClient, private store: AppStateService) {}

  public createPurchase(
    purchase: PurchaseCreationModel
  ): Observable<CommandResponse<PurchaseModel>> {
    return this.httpClient
      .post<CommandResponse<PurchaseModel>>(
        `${environment.apiUrl}/${this.controller}/${this.createAction}`,
        purchase
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.purchases.next([...this.store.purchases.value, response.responseModel]);
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public getPurchases(): Observable<CommandResponse<PurchaseModel[]>> {
    return this.httpClient
      .get<CommandResponse<PurchaseModel[]>>(
        `${environment.apiUrl}/${this.controller}/${this.getAllAction}`,
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.purchases.next(response.responseModel);
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public deletePurchase(id: string): Observable<CommandResponse<null>> {
    return this.httpClient
      .post<CommandResponse<null>>(
        `${environment.apiUrl}/${this.controller}/${this.deleteAction}`,
        new DeleteCommand(id)
      )
      .pipe(
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }
}

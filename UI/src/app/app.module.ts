import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatDialogModule } from "@angular/material/dialog";
import { IdentityModule } from "./services/identity.module";
import { IdentityService } from "./services/identity/identity.service";
import { CommonModule } from "@angular/common";
import { AccountModule } from "./account/account.module";
import { TabsModule } from "./nav-menu/tabs/tabs.module";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { DialogsModule } from "./dialogs/dialogs.module";
import { UserAccountPageComponent } from "./account/user-account-page/user-account-page.component";
import { AuthGuard } from "./services/identity/auth-guard/auth-guard";
import { PurchasesModule } from "./purchase-processing/purchases.module";
import { JwtInterceptor } from "./services/identity/jwt.interceptor";

@NgModule({
  declarations: [AppComponent, HomeComponent, NavMenuComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    MatDialogModule,
    TabsModule,
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    AccountModule,
    IdentityModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
    ]),
    BrowserAnimationsModule,
    PurchasesModule,
    DialogsModule,
  ],
  providers: [
    IdentityService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { IdentityService } from "../services/identity/identity.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.scss"],
})
export class NavMenuComponent implements OnInit {
  public isExpanded = false;
  public currentEnvironment!: string;
  public service: IdentityService;

  public constructor(svc: IdentityService, private router: Router) {
    this.service = svc;
  }

  ngOnInit(): void {
    this.service.currentEnvironment$.subscribe(
      (env) => (this.currentEnvironment = env)
    );
  }

  public showAccount() {
    const userId = this.service.userValue.id;
    this.router.navigateByUrl(`account/${userId}`);
  }

  public collapse(): void {
    this.isExpanded = false;
  }

  public toggle(): void {
    this.isExpanded = !this.isExpanded;
  }

  public logout(): void {
    this.service.logout();
  }
}

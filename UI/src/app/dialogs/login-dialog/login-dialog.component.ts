import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { SignInRequest } from "src/app/models/identity/requests/signInRequest";
import { IdentityService } from "src/app/services/identity/identity.service";

@Component({
  selector: "app-login-dialog",
  templateUrl: "./login-dialog.component.html",
  styleUrls: ["./login-dialog.component.scss"],
})
export class LoginDialogComponent implements OnInit {
  public userNameValue = "";
  public passwordValue = "";
  public isLoginSucceeded = true;
  public errorMessage!: string;
  public profileForm!: FormGroup;
  public email = new FormControl("", [Validators.required, Validators.email]);
  public userName = new FormControl("", [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(25),
  ]);
  public password = new FormControl("", [
    Validators.required,
    Validators.minLength(6),
    Validators.maxLength(20),
  ]);

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private identityService: IdentityService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onDialogClosing(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
    this.profileForm = new FormGroup({
      userName: new FormControl(this.userNameValue, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(25),
      ]),
      password: new FormControl(this.passwordValue, [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20),
      ]),
    });
  }

  public getErrorMessage(control: FormControl): string {
    if (control.hasError('required')) {
      return 'This field id required.';
    }

    if (control.hasError('minLength')) {
      return 'Minimal length rule violation.';
    }

    if (control.hasError('maxLength')) {
      return 'Maximal length rule violation.';
    }

    return 'Wrong data given.';
  }

  public onLoginFormSubmit(): void {
    const request = new SignInRequest(
      this.profileForm.controls["userName"].value,
      this.profileForm.controls["password"].value
    );

    this.identityService.signIn(request).subscribe(
      (response) => {
        console.log(response);
        if (response.succeeded) {
          this.dialogRef.close();
          this.isLoginSucceeded = true;
          this.router.navigateByUrl(`account/${response.user.id}`);
        } else {
          this.isLoginSucceeded = false;
          this.errorMessage = response.errors[0];
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

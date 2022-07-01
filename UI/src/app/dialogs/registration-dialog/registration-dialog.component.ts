import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { SignUpRequest } from "src/app/models/identity/requests/signUpRequest";
import { IdentityService } from "src/app/services/identity/identity.service";

@Component({
  selector: "app-registration-dialog",
  templateUrl: "./registration-dialog.component.html",
  styleUrls: ["./registration-dialog.component.scss"],
})
export class RegistrationDialogComponent implements OnInit {
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
    private dialogRef: MatDialogRef<RegistrationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private identityService: IdentityService,
    private router: Router
  ) {}

  onDialogClosing(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
    this.profileForm = new FormGroup({
      email: this.email,
      userName: this.userName,
      password: this.password
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

  public onRegistrationFormSubmit(): void {
    const signUpRequest = new SignUpRequest(
      this.profileForm.controls["email"].value,
      this.profileForm.controls["userName"].value,
      this.profileForm.controls["password"].value
    );

    this.identityService.signUp(signUpRequest).subscribe(
      (response) => {
        this.dialogRef.close();
        this.router.navigateByUrl(`account/${response.user.id}`);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

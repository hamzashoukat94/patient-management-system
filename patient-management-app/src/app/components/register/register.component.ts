import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';

import { Registration } from 'src/app/interfaces/registration';
import { AlertService } from 'src/app/services/alert.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthenticationService,
      private userService: UserService,
      private alertService: AlertService
  ) {
      // redirect to home if already logged in
      if (this.authenticationService.currentUserValue) {
          this.router.navigate(['/']);
      }
  }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern(/^(?=.*[!@#$%^&*()\-_=+{}[\]:"|;'<>,.?/])(?=.*\d)(?=.*[A-Z]).+$/)]],
      confirmpassword: ['', [Validators.required, Validators.pattern(/^(?=.*[!@#$%^&*()\-_=+{}[\]:"|;'<>,.?/])(?=.*\d)(?=.*[A-Z]).+$/)]]
    },
    { validators: this.ConfirmedValidator('password', 'confirmpassword')});
  }

  ConfirmedValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (
        matchingControl.errors &&
        !matchingControl.errors['confirmedValidator']
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ 'confirmedValidator': true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }


  passwordMatchValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmpassword');
    if (!password || !confirmPassword) {
      return null;
    }

    if (password.value !== confirmPassword.value) {
      return { passwordMatch: true };
    }

    return null;
  }

  validateControl(controlName: string): any {
    const control = this.registerForm.get(controlName);
    return control ? control.invalid && control.touched : false;
  }

  hasError(controlName: string, errorName: string): any {
    const control = this.registerForm.get(controlName);
    return control ? control.hasError(errorName) : false;
  }
 // convenience getter for easy access to form fields
 get f() { return this.registerForm.controls; }

 onSubmit() {
     this.submitted = true;

     // reset alerts on submit
     this.alertService.clear();

     // stop here if form is invalid
     if (this.registerForm.invalid) {
         return;
     }

     this.loading = true;
     const registrationDto : Registration = this.registerForm.value;
     this.userService.register(registrationDto)
         .pipe(first())
         .subscribe(
             data => {
                 this.alertService.success('Registration successful', true);
                 this.router.navigate(['/login']);
             },
             error => {
                 this.alertService.error(error.message);
                 this.loading = false;
             });
 }
}

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
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[!@#$%^&*()\-_=+{}[\]:"|;'<>,.?/])(?=.*\d)(?=.*[A-Z]).+$/)]),
      confirmpassword: new FormControl('', [Validators.required, this.passwordMatchValidator()])
    });
  }

  passwordMatchValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const password = control.get('password');
      const confirm = control.get('confirm');

      if (password && confirm && password.value !== confirm.value) {
        return { passwordMismatch: true };
      }

      return null;
    };
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

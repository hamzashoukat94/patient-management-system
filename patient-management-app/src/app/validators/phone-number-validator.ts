import { AbstractControl, ValidatorFn } from '@angular/forms';

export function phoneNumberValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const phoneNumberRegex = /^[0-9]{14}$/; // Regex pattern for a 10-digit phone number

    const valid = phoneNumberRegex.test(control.value);

    return valid ? null : { phoneNumber: true };
  };
}

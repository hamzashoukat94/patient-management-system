import { AbstractControl, ValidatorFn } from '@angular/forms';

export function phoneNumberValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const phoneNumberRegex = /^[0-9]{11}$/; // Regex pattern for a 11-digit phone number

    const valid = phoneNumberRegex.test(control.value);

    return valid ? null : { phoneNumber: true };
  };
}

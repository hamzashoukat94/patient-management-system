import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Patient } from 'src/app/interfaces/patient';
import { PatientCreation } from 'src/app/interfaces/patient-creation';
import { PatientService } from 'src/app/services/patient.service';
import { emailValidator } from 'src/app/validators/email-validator';
import { phoneNumberValidator } from 'src/app/validators/phone-number-validator';

@Component({
  selector: 'app-manage-patient',
  templateUrl: './manage-patient.component.html',
  styleUrls: ['./manage-patient.component.css'],
})
export class ManagePatientComponent implements OnInit {
  constructor(
    private patientService: PatientService,
    private formBuilder: FormBuilder
  ) {}
  patients!: Patient[];
  patientForm!: FormGroup;
  modalMod!: string;
  openedPatient!: Patient;

  ngOnInit(): void {
    this.getAllPatients();
    this.patientForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      email: new FormControl('', [
        Validators.required,
        emailValidator(),
      ]),
      contact: new FormControl('', [
        Validators.required,
        phoneNumberValidator(),
      ]),
    });
  }

  getAllPatients(): any {
    this.patientService.getAllPatients().subscribe({
      next: (data) => {
        this.patients = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  AddPatientButton() {
    this.modalMod = 'add';
    this.ClearPatientForm();
  }

  AddUpdatePatient() {
    switch (this.modalMod) {
      case 'add':
        const patientCreation: PatientCreation = this.patientForm.value;
        this.patientService.createPatient(patientCreation).subscribe({
          next: (data) => {
            console.log(data);
            this.getAllPatients();
          },
          error: (error) => {
            console.log(error);
          },
        });

        this.ClearPatientForm();
        break;
      case 'update':
        const patientUpdate: Patient = this.patientForm.value;
        patientUpdate.id = this.openedPatient.id;
        this.patientService.updatePatient(patientUpdate).subscribe({
          next: (data) => {
            console.log(data);
            this.getAllPatients();
          },
          error: (error) => {
            console.log(error);
          },
        });

        this.ClearPatientForm();
        break;
    }
  }
  RemovePatient(patient: Patient) {
    this.patientService.deletePatient(patient.id).subscribe({
      next: (data) => {
        console.log(data);
        this.getAllPatients();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  EditOpenModal(patient: Patient) {
    this.modalMod = 'update';
    this.openedPatient = patient;
    this.populateForm(patient);
  }

  populateForm(patient: Patient): void {
    this.patientForm.patchValue({
      name: patient.name,
      address: patient.address,
      email: patient.email,
      contact: patient.contact,
    });
  }

  ClearPatientForm(): void {
    this.patientForm.patchValue({
      name: '',
      address: '',
      email: '',
      contact: '',
    });
  }
}

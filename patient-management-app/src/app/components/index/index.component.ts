import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/interfaces/patient';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  patients!: Patient[];

  constructor(private patientService: PatientService) { }

  ngOnInit() {
    this.getAllPatients();
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

}

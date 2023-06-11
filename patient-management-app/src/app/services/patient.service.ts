import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Patient } from '../interfaces/patient';
import { environment } from 'src/environments/environment';
import { PatientCreation } from '../interfaces/patient-creation';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  constructor(private httpClient: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders().set('Content-Type', 'application/json'),
  };

  getAllPatients(): Observable<Patient[]> {
    return this.httpClient.get<Patient[]>(
      environment.patientUrl,
      this.httpOptions
    );
  }

  getPatient(patientId: number): Observable<Patient> {
    return this.httpClient
      .get<Patient>(`${environment.patientUrl}/${patientId}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  deletePatient(patientId: number): Observable<any> {
    return this.httpClient
      .delete(`${environment.patientUrl}?patientId=${patientId}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  updatePatient(updatedPatient: Patient) {
    return this.httpClient
      .put<Patient>(`${environment.patientUrl}`, updatedPatient, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  createPatient(patientCreation: PatientCreation): Observable<any> {
    return this.httpClient
      .post<PatientCreation>(
        `${environment.patientUrl}`,
        patientCreation,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  handleError(error: any) {
    let errorMessage = '';
    if (error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error code: ${error.status} \nMessage: ${error.Message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}

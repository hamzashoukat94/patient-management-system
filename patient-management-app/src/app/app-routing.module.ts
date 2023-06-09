import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './components/index/index.component';
import { ManagePatientComponent } from './components/manage-patient/manage-patient.component';

const routes: Routes = [
  {
    path: '',
    component: IndexComponent
  }, {
    path: 'managePatient',
    component: ManagePatientComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

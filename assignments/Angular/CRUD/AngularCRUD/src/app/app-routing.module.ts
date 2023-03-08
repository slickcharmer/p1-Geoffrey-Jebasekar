import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/employees/edit-employee/edit-employee.component';
import { EmployeeListComponent } from './components/employees/employee-list/employee-list.component';

const routes: Routes =
[
  {
    path: '',
    component: EmployeeListComponent
  },
  {
    path: 'employees',
    component: EmployeeListComponent
  },
  {
    path: 'employees/add',
    component: AddEmployeeComponent
  },
  {
    path: 'employees/edit/:id',
    component: EditEmployeeComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

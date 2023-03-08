import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'Models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {

  addEmployee : Employee  =

    {
      id: '',
      name : '',
      email: '',
      phone : 0,
      salary : 0,
      department : ''
    }

/**
 *
 */
constructor(private employeeService : EmployeesService , private router: Router)
{


}

  addEmployeeFunc()
  {
    // console.log(this.addEmployee);
    this.employeeService.addEmployee(this.addEmployee)
    .subscribe({
      next  : (employee) => {
      console.log(employee)
      this.router.navigate(['employees']);
      },
      error : (response) => {
        console.log(response)
        }

    });

  }

}

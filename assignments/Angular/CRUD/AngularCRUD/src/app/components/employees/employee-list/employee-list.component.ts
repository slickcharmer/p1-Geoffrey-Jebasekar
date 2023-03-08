import { Component,OnInit } from '@angular/core';
import { Employee } from 'Models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent
{

  // employees: Employee[] =
  // [

  //   {
  //     id:'1',
  //     name: 'Geff',
  //     email: 'geffsehlby@gmail.com',
  //     phone: 9876543210,
  //     salary:222234567,
  //     department:'HR'

  //   },
  //   {
  //     id:'2',
  //     name: 'Thomas',
  //     email: 'thomassehlby@gmail.com',
  //     phone: 9876543211,
  //     salary:222234467,
  //     department:'IT'

  //   },
  //   {
  //     id:'3',
  //     name: 'Arthur',
  //     email: 'arthursehlby@gmail.com',
  //     phone: 9876543212,
  //     salary:222234599,
  //     department:'Networking'

  //   },
  // ];
  employees : Employee[]  =
  [

  ];

  constructor(private employeeService : EmployeesService)
  {

  }
  ngOnInit() : void
  {


    this.employeeService.getAllEmployees()
    .subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error : (response) => {
        console.log(response);
      }



    });


  }


}

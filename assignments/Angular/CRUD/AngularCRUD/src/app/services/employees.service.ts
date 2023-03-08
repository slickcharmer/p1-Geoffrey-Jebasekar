import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Employee } from 'Models/employee.model';

@Injectable({providedIn: 'root'})
export class ServiceNameService {
  constructor(private httpClient: HttpClient) { }

}

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseapiurl: string = "https://localhost:7017";

  constructor(private http : HttpClient)
  {



   }

  getAllEmployees() : Observable<Employee[]>
  {

    return this.http.get<Employee[]>(this.baseapiurl + '/api' + '/Employees');

  }
  addEmployee(addEmployee : Employee) : Observable<Employee>
  {
    addEmployee.id = '00000000-0000-0000-0000-000000000000'
                                                                            // This is req body
    return this.http.post<Employee>(this.baseapiurl + '/api' + '/Employees' , addEmployee);

  }
  getEmployeee(id : string) : Observable<Employee>
  {
    return this.http.get<Employee>(this.baseapiurl + '/api' + '/Employees' + '/' + id);
  }
  updateEmployee(id : string , updateEmployeeRequest : Employee) : Observable<Employee>
  {
    return this.http.put<Employee>(this.baseapiurl + '/api' + '/Employees' + '/' + id,updateEmployeeRequest);


  }

  deleteEmployee(id :  string ) : Observable<Employee>
  {
    return this.http.delete<Employee>(this.baseapiurl + '/api' + '/Employees' + '/' + id);

  }
}

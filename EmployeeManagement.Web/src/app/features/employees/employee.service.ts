import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmployeeAddRequest } from './models/employee-add-request';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeesApiUrl = 'http://localhost:5201/api/employees';
  
  constructor(private http: HttpClient) { }

  searchEmployees(name: string, title: string): Observable<any> {
    let params = new HttpParams();
    params = params.set('name', name);
    params = params.set('title', title);
    return this.http.get(`${this.employeesApiUrl}/search`, { params });
  }

  getEmployeeSalariesByTitle(): Observable<any> {
    return this.http.get(`${this.employeesApiUrl}/salaries`);
  }

  addEmployee(employee: IEmployeeAddRequest): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    }); 
    return this.http.post(this.employeesApiUrl, employee, {headers: headers});
  }
}

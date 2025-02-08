import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { SharedModule } from '../../../shared.module';
import { IEmployeeSalaryResponse } from '../models/employee-salary-response';

@Component({
  selector: 'app-employee-salaries',
  imports: [SharedModule],
  templateUrl: './employee-salaries.component.html',
  styleUrl: './employee-salaries.component.scss'
})
export class EmployeeSalariesComponent implements OnInit {
  employeeSalaries: IEmployeeSalaryResponse[] = [];
  displayedColumns: string[] = ['title', 'maxSalary', 'minSalary'];
  isLoading: boolean = false;
  
  constructor(private employeeService: EmployeeService) { }
  
  ngOnInit(): void {
    this.isLoading = true;
    this.employeeService.getEmployeeSalariesByTitle().subscribe(res => {
      this.employeeSalaries = res;
      this.isLoading = false;
    });
  }
}

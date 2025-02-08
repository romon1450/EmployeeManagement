import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { SharedModule } from '../../../shared.module';
import { IEmployeeSearchResponse } from '../models/employee-search-response';

@Component({
  selector: 'app-employee-search',
  imports: [SharedModule],
  standalone: true,
  templateUrl: './employee-search.component.html',
  styleUrl: './employee-search.component.scss'
})
export class EmployeeSearchComponent implements OnInit {
  employees: IEmployeeSearchResponse[] = [];
  displayedColumns: string[] = ['name', 'joinDate', 'title', 'salary'];
  isLoading: boolean = false;
  name: string = '';
  title: string = '';

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.searchEmployees();
  }

  searchEmployees(): void {
    this.isLoading = true;
    this.employeeService.searchEmployees(this.name, this.title).subscribe(res => {
      this.employees = res;
      this.isLoading = false;
    });
  }
}

import { Component } from '@angular/core';
import { SharedModule } from '../../../shared.module';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { IEmployeeAddDto, EmployeeAddDto } from '../models/employee-add-dto';

@Component({
  selector: 'app-employee-add',
  providers: [provideNativeDateAdapter()],
  imports: [SharedModule, MatDatepickerModule],
  templateUrl: './employee-add.component.html',
  styleUrl: './employee-add.component.scss'
})
export class EmployeeAddComponent {
  employee: IEmployeeAddDto = new EmployeeAddDto();

  constructor(private employeeService: EmployeeService, private router: Router) { }

  addEmployee() {
    this.employeeService.addEmployee(this.employee).subscribe(res => this.navigateToHome());
  }

  navigateToHome(): void {
    this.router.navigate(['/home']);
  }
}

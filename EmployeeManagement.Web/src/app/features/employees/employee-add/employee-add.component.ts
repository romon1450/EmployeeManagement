import { Component } from '@angular/core';
import { SharedModule } from '../../../shared.module';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { IEmployeeAddRequest, EmployeeAddRequest } from '../models/employee-add-request';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-employee-add',
  providers: [provideNativeDateAdapter()],
  imports: [SharedModule, MatDatepickerModule],
  templateUrl: './employee-add.component.html',
  styleUrl: './employee-add.component.scss'
})
export class EmployeeAddComponent {
  employee: IEmployeeAddRequest = new EmployeeAddRequest();
  isAddDisabled: boolean = false;
  minDob: Date = new Date();
  maxDob: Date = new Date();
  minJoinDate: Date = new Date();
  today: Date = new Date();

  constructor(private employeeService: EmployeeService, private router: Router, private snackBar: MatSnackBar) {
    this.minDob.setFullYear(this.today.getFullYear() - 64);
    this.maxDob.setFullYear(this.today.getFullYear() - 22);
  }

  addEmployee(): void {
    if (this.isFormInputValid()) {
      this.snackBar.dismiss();
      this.isAddDisabled = true;
      this.employeeService.addEmployee(this.employee).subscribe(res => this.navigateToHome());
    }
  }

  navigateToHome(): void {
    this.router.navigate(['/home']);
  }

  isFormInputValid(): boolean {
    this.employee.name = this.employee.name.trim();
    if (this.employee.name.length == 0) {
      this.displayError('Name is missing.');
      return false;
    }

    this.employee.ssn = this.employee.ssn.trim();
    if (this.employee.ssn.length == 0) {
      this.displayError('SSN is missing.');
      return false;
    }

    if (this.employee.dob == null) {
      this.displayError('Date of Birth is missing.');
      return false;
    }

    this.employee.address = this.employee.address.trim();
    if (this.employee.address.length == 0) {
      this.displayError('Address is missing.');
      return false;
    }

    this.employee.city = this.employee.city.trim();
    if (this.employee.city.length == 0) {
      this.displayError('City is missing.');
      return false;
    }

    this.employee.state = this.employee.state.trim();
    if (this.employee.state.length == 0) {
      this.displayError('State is missing.');
      return false;
    }

    this.employee.zip = this.employee.zip.trim();
    if (this.employee.zip.length == 0) {
      this.displayError('Zip is missing.');
      return false;
    }

    this.employee.phone = this.employee.phone.trim();
    if (this.employee.phone.length == 0) {
      this.displayError('Phone is missing.');
      return false;
    }

    if (this.employee.joinDate == null) {
      this.displayError('Join date is missing.');
      return false;
    }
    if (this.employee.joinDate < this.minJoinDate) {
      this.displayError(`Join date must not be earlier than ${this.minJoinDate.toDateString()}.`);
      return false;
    }
    
    if (this.employee.exitDate != null && this.employee.exitDate < this.employee.joinDate) {
      this.displayError('Exit date must not be earlier than the join date.');
      return false;
    }

    this.employee.title = this.employee.title.trim();
    if (this.employee.title.length == 0) {
      this.displayError('Title is missing.');
      return false;
    }

    if (this.employee.salary == null) {
      this.displayError('Salary is missing.');
      return false;
    }
    if (this.employee.salary < 0) {
      this.displayError('Salary must not be a negative value.');
      return false;
    }
    if (this.employee.salary > 2147483647) {
      this.displayError('Salary must be less than 2,147,483,647.');
      return false;
    }

    return true;
  }
  
  displayError(message: string): void {
    this.snackBar.open(`Error: ${message}`, 'Close');
  }

  setMinJoinDate(): void {
    if (this.employee.dob != null) {
      this.minJoinDate = new Date(this.employee.dob);
      this.minJoinDate.setFullYear(this.employee.dob.getFullYear() + 22);
    }
  }
}

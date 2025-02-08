import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { EmployeeSearchComponent } from './features/employees/employee-search/employee-search.component';
import { EmployeeSalariesComponent } from './features/employees/employee-salaries/employee-salaries.component';
import { EmployeeAddComponent } from './features/employees/employee-add/employee-add.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'employees/search', component: EmployeeSearchComponent },
    { path: 'employees/salaries', component: EmployeeSalariesComponent },
    { path: 'employees/add', component: EmployeeAddComponent },
    { path: '**',   redirectTo: '/home' },
    { path: '',   redirectTo: '/home', pathMatch: 'full' }
];

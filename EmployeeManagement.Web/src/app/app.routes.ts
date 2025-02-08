import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { EmployeeSearchComponent } from './features/employees/employee-search/employee-search.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'employees/search', component: EmployeeSearchComponent },
    { path: '',   redirectTo: '/home', pathMatch: 'full' }
];

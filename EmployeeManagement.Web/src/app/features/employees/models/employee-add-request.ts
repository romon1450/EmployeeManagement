export interface IEmployeeAddRequest {
    name: string;
    ssn: string;
    dob: Date | null;
    address: string;
    city: string;
    state: string;
    zip: string;
    phone: string;
    joinDate: Date | null;
    exitDate: Date | null;
    salary: IEmployeeSalaryAddRequest;
}

export interface IEmployeeSalaryAddRequest {
    fromDate: Date | null;
    toDate: Date | null;
    title: string;
    salary: number;
}

export class EmployeeAddRequest implements IEmployeeAddRequest {
    name: string = '';
    ssn: string = '';
    dob: Date | null = null;
    address: string = '';
    city: string = '';
    state: string = '';
    zip: string = '';
    phone: string = '';
    joinDate: Date | null = null;
    exitDate: Date | null = null;
    salary: IEmployeeSalaryAddRequest = new EmployeeSalaryAddRequest();
}

export class EmployeeSalaryAddRequest implements IEmployeeSalaryAddRequest {
    fromDate: Date | null = null;
    toDate: Date | null = null;
    title: string = '';
    salary: number = 0;
}
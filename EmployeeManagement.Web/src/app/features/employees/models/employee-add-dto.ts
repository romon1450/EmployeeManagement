export interface IEmployeeAddDto {
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
    salary: IEmployeeSalaryAddDto;
}

export interface IEmployeeSalaryAddDto {
    fromDate: Date | null;
    toDate: Date | null;
    title: string;
    salary: number;
}

export class EmployeeAddDto implements IEmployeeAddDto {
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
    salary: IEmployeeSalaryAddDto = new EmployeeSalaryAddDto();
}

export class EmployeeSalaryAddDto implements IEmployeeSalaryAddDto {
    fromDate: Date | null = null;
    toDate: Date | null = null;
    title: string = '';
    salary: number = 0;
}
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
    title: string;
    salary: number | null;
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
    title: string = '';
    salary: number | null = null;
}
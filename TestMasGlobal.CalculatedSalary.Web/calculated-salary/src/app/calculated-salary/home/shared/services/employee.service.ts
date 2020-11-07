import { EmployeeModel } from '../models/employeed.model';
import { ServicioBaseService } from 'src/app/shared/service-base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SesionService } from 'src/app/calculated-salary/login/shared/services/sesion.service';

@Injectable({ providedIn: 'root' })
export class EmployeeService extends  ServicioBaseService<EmployeeModel>{
    resource = 'Employee';
    isToken = true;
    constructor( http: HttpClient,  sesionService:SesionService){
        super(http, sesionService);
        
    }

    getAll(){
        return super.getAll();
    }

    get(id: number) {
        return super.get(id);
    }

    post(data: any){
        return super.post(data);
    }
}
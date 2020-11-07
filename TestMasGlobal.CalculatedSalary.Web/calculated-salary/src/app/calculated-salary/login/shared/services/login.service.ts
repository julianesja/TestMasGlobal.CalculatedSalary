import { Injectable } from '@angular/core';
import { UserSession } from '../model/userSession.model';
import { ServicioBaseService } from 'src/app/shared/service-base.service';
import { HttpClient } from '@angular/common/http';
import { SesionService } from './sesion.service';

@Injectable({ providedIn: 'root' })
export class LoginService extends  ServicioBaseService<UserSession>{

    resource = 'Account';
    isToken = false;
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

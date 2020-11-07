import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SesionService } from './../calculated-salary/login/shared/services/sesion.service';
import { environment } from 'src/environments/environment';


@Injectable()
export abstract class ServicioBaseService<T> {
    protected resource: string
    protected isToken: boolean
    constructor(private http: HttpClient
        , private sesionService:SesionService
        ){}

    protected getAll(){
        if(this.isToken){
            return this.http.get<T[]>(`${environment.url}/${this.resource}`, this.sesionService.getHeaders());
        }else{
            return this.http.get<T[]>(`${environment.url}/${this.resource}`);
        }
        
    }
    protected get(id: number) {
        if(this.isToken){
            return this.http.get<T>(`${environment.url}/${this.resource}/${id}`,this.sesionService.getHeaders());
        }else{
            return this.http.get<T>(`${environment.url}/${this.resource}/${id}`);
        }
        
    }
    protected post(data: any){
        if(this.isToken){
            return this.http.post<T>(`${environment.url}/${this.resource}`, data,this.sesionService.getHeaders());
        }else{
            return this.http.post<T>(`${environment.url}/${this.resource}`, data);
        }
        
    }
    
}
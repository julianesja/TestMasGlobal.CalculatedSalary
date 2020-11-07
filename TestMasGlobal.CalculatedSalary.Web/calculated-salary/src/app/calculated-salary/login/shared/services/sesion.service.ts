import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

import { HttpHeaders } from '@angular/common/http';
import { UserSession } from '../model/userSession.model';

@Injectable({ providedIn: 'root' })
export class SesionService {
    private storage = window.localStorage;
    constructor() { }

    private getItem(key: string) {
        return this.storage.getItem(key);
    }

    private setItem(key: string, data: any) {
        this.storage.setItem(key, JSON.stringify(data));
    }

    private removeItem(key: string) {
        this.storage.removeItem(key);
    }

    CloseSession() {
        this.removeItem(environment.userKey);
    }

    getHeaders(){
        const token = this.getTokenUser();
        const options = {
            headers: new HttpHeaders({
                authorization: token ? `Bearer ${token}` : ''
            })
        };
        return options;
    }

    getTokenUser(): string {
        const userModel = <UserSession>JSON.parse(this.getItem(environment.userKey));
        if (userModel !== null) {
            return userModel.token;
        }
        return '';
    }

    getCurrentUser(): UserSession {
        const userModel = <UserSession>JSON.parse(this.getItem(environment.userKey));
        return userModel;
    }

    saveLocalUser(inicioSesion: UserSession) {
        this.removeItem(environment.userKey);
        this.setItem(environment.userKey, inicioSesion);
    }


}
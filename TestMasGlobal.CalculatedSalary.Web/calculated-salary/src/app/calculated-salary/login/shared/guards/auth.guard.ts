import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { SesionService } from '../services/sesion.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private sesionService: SesionService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.sesionService.getCurrentUser()) {
            return true;
        }
        this.sesionService.CloseSession();
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
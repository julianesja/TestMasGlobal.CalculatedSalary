import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { SesionService } from '../services/sesion.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private sesionService: SesionService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.sesionService.obtenerTokenUsuario()) {
            return true;
        }
        this.sesionService.cerrarSession();
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './calculated-salary/login/login.component';
import { AuthGuard } from './calculated-salary/login/shared/guards/auth.guard';
import { HomeComponent } from './calculated-salary/home/home.component';



const routes: Routes = [
  {
    path: 'home',
    canActivate: [AuthGuard],
   component: HomeComponent
},
  { path: 'logout', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeModel } from './shared/models/employeed.model';
import { EmployeeService } from './shared/services/employee.service';
import { SesionService } from '../login/shared/services/sesion.service';
import {Router} from "@angular/router"

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public form: FormGroup;
  public dataSource: EmployeeModel[];
  public displayedColumns: string[] = ['name', 'contractTypeName', 'roleId', 'roleName', 'roleDescription', 'hourlySalary', 'monthlySalary'];
  constructor(private fb: FormBuilder,
     private employeeService:EmployeeService,
      private sesionService:SesionService,
      private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      employeid: [''],
    });    
  }
  search(){
    if(this.form.value.employeid == null || this.form.value.employeid == ''){
      this.employeeService.getAll().subscribe(
        data => {
          this.dataSource = data;
        },
        error => {console.log(error);}
      );
    }else{
      this.employeeService.get(this.form.value.employeid).subscribe(
        data => {
          this.dataSource = [data];
        },
        error => {console.log(error);}
      );
    }
  }

  logout(){
    this.sesionService.CloseSession();
    this.router.navigate(['/login'])
  }
}

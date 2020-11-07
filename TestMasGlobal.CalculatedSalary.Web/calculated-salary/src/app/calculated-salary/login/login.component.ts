import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { LoginService } from './shared/services/login.service';
import {LoginModel} from './shared/model/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public form: FormGroup;
  constructor(private fb: FormBuilder, private loginService: LoginService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      user: ['', Validators.required],
      password: ['', Validators.required],
     
    });    
  }

  signIn(){
    if (this.form.valid) {
      var login: LoginModel = {
        password : this.form.value.password,
        user: this.form.value.user
      };
      this.loginService.post(login).subscribe(
        data => {
          console.log(data);
        }
      );
    }
  }


}

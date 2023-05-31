import {Component, OnInit} from '@angular/core';
import {NgForm, ValidationErrors} from "@angular/forms";

import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {UserService} from "../../_services/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  formModel = {
    UserName: '',
    Password: ''
  }

  constructor(private userService: UserService, private router: Router, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null){
      this.router.navigate(['/home']);
    }
  }

  onSubmit(form: NgForm) {
    this.userService.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');

        console.log('logged in');
        this.toastr.success('Login Successful', 'Login');
        this.userService.setLoggedIn(true);
        this.userService.setFullName(res.fullName);
        this.userService.setUserId(res.userId);
      },
      err => {
          console.log(err);
          this.toastr.error('Login Failed',  'Login');
      }
    );
  }

}

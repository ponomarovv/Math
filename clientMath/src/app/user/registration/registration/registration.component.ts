import {Component, OnInit} from '@angular/core';
import {ToastrService} from "ngx-toastr";
import {ValidationErrors} from "@angular/forms";
import {UserService} from "../../../_services/user.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public userService: UserService, private toastr: ToastrService, private router: Router) {
  }

  ngOnInit(): void {
    this.userService.formModel.reset();
  }

  onSubmit() {
    this.userService.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.userService.formModel.reset();
          this.toastr.success('New user created', 'Registration successful.');
          this.router.navigateByUrl('user/login');
        } else {
          res.errors.forEach((element: ValidationErrors|any) => {
            switch (element.code) {
              case 'DuplicateUserName' :
                this.toastr.error('username has already been taken',  'Registration failed');
                break;

              default:
                this.toastr.error(element.description,  'Registration failed');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}

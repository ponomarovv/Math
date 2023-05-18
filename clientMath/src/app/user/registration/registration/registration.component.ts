import {Component, OnInit} from '@angular/core';
import {ToastrService} from "ngx-toastr";
import {ValidationErrors} from "@angular/forms";
import {UserService} from "../../../_services/user.service";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created', 'Registration successful.');
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

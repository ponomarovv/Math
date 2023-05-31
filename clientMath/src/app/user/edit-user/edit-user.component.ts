import {Component, OnInit} from '@angular/core';
import {UserService} from "../../_services/user.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user: any;


  constructor(
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.user = {
      fullName: '',
      email: ''
    };
  }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      (res: any) => {
        this.user.id = res.id;
        this.user.email = res.email;
        this.user.fullName = res.fullName;


        console.log('got user data');
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  onSubmit() {
    console.log('before');
    console.log(this.user);
    this.userService.updateUser(this.user).subscribe(
      () => {
        console.log('after');
        console.log(this.user);
        this.toastr.success('User updated successfully', 'Edit Profile');
        this.router.navigateByUrl('showUserInfo');
      },
      (error: any) => {
        this.toastr.error('Error updating user', 'Edit Profile');
        console.log(error);
      }
    );
  }


}

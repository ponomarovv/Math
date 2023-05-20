import {Component, OnInit} from '@angular/core';

import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {UserService} from "../_services/user.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  isLoggedIn: any;

  constructor(private router: Router, private toastr: ToastrService, private userService: UserService) {
  }

  ngOnInit(): void {
    // this.showLogout = localStorage.getItem('token');
    this.userService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;
    });
  }

  SignOut() {
    localStorage.clear();
    this.router.navigate(['/user/login']);

    this.isLoggedIn = null;
    console.log('logged out');

    this.userService.setLoggedIn(false)
    this.toastr.success('Logout successful', 'Logout');
  }

  ShowProfile(){
  }

  EditProfile(){
  }

  DeleteProfile(){
  }

}

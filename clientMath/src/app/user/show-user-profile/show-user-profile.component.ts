import {Component, OnInit} from '@angular/core';
import {UserService} from "../../_services/user.service";

@Component({
  selector: 'app-show-user-profile',
  templateUrl: './show-user-profile.component.html',
  styleUrls: ['./show-user-profile.component.css']
})
export class ShowUserProfileComponent implements OnInit{

  constructor(private userService: UserService) {
  }

  userProfile: any;

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      (res: any) => {
        this.userProfile = res;
        console.log('got user data');
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}

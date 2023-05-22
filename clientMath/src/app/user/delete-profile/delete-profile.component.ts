import {Component} from '@angular/core';
import {UserService} from "../../_services/user.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {SharedService} from "../../_services/shared.service";

@Component({
  selector: 'app-delete-profile',
  templateUrl: './delete-profile.component.html',
  styleUrls: ['./delete-profile.component.css']
})
export class DeleteProfileComponent {
  constructor(private userService: UserService, private router: Router, private toastr: ToastrService, private sharedService: SharedService) {
  }

  userProfile: any;

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      (res: any) => {
        this.userProfile = res;
        console.log('ready to delete');



      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  deleteProfile(userId: string) {
    console.log(userId);
    console.log(this.userProfile.id);

    this.userService.deleteProfile(userId).subscribe(
      () => {

        // Profile deleted successfully, handle any additional logic
      },
      (error: any) => {
        // Handle error if the profile deletion fails
      }
    );

    this.sharedService.setFullName('Guest');
    this.sharedService.setIsLoggedIn('');

    this.toastr.success('Delete Successful', 'Delete');

    localStorage.clear();
    console.log('really was killed');

    this.router.navigate(['user/login']);
  }

  yes(){
    this.deleteProfile(this.userProfile.id); // Call deleteProfile after fetching the user profile
  }

  no(){
    this.router.navigate(['home']);
  }
}

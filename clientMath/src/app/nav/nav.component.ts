import { Component, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../_services/user.service';
import { SharedService } from '../_services/shared.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  isLoggedIn: any;
  fullName: string = '';

  isBurgerMenuOpen: boolean = false;
  isProfileButtonsVisible: boolean = true;

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private userService: UserService,
    private sharedService: SharedService
  ) {}

  ngOnInit(): void {
    this.sharedService.fullName$.subscribe(fullName => {
      this.fullName = fullName;
    });

    this.sharedService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;
    });

    this.userService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;
    });

    this.userService.fullName$.subscribe(fullName => {
      this.fullName = fullName;
    });
  }

  @HostListener('window:resize', ['$event'])
  onWindowResize(event: Event) {
    this.updateButtonVisibility();
  }

  toggleBurgerMenu() {
    this.isBurgerMenuOpen = !this.isBurgerMenuOpen;
    this.updateButtonVisibility();
  }

  private updateButtonVisibility() {
    const windowWidth = window.innerWidth;
    if (windowWidth <= 768) {
      this.isProfileButtonsVisible = !this.isBurgerMenuOpen;
    } else {
      this.isProfileButtonsVisible = true;
    }
  }

  SignOut() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
    this.isLoggedIn = null;
    console.log('logged out');
    this.userService.setLoggedIn(false);
    this.toastr.success('Logout successful', 'Logout');
    this.fullName = 'Guest';
  }
}

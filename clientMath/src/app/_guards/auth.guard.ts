import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {map, Observable} from 'rxjs';
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService, private router: Router) {
  }


  // canActivate(): Observable<boolean> {
  //   return this.accountService.currentUser$.pipe(
  //     map(user => {
  //       if (user) return true;
  //       else {
  //         this.toastr.error('You shall not pass!');
  //         return false;
  //       }
  //     }));
  // }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null) return true;

    this.router.navigate(['/user/login']);
    return false;
  }

}

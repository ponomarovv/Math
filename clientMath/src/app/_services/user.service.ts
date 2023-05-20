import {Injectable, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable, tap} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService implements OnInit {

  private isLoggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();

  private fullNameSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public fullName$: Observable<string> = this.fullNameSubject.asObservable();

  private userIdSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public userId$: Observable<string> = this.userIdSubject.asObservable();



  constructor(private fb: FormBuilder, private http: HttpClient) {
    const isLoggedIn = !!localStorage.getItem('token');
    this.isLoggedInSubject.next(isLoggedIn);
  }

  ngOnInit(): void {
  }

  readonly BaseURI = environment.apiUrl;


  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, {validator: this.comparePasswords})

  });

  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    // passwordMismatch
    // confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password')?.value !== confirmPswrdCtrl?.value) {
        confirmPswrdCtrl?.setErrors({passwordMismatch: true});
      } else {
        confirmPswrdCtrl?.setErrors(null);
      }
    }
  }


  register() {
    let body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + 'ApplicationUser/Register', body);
  }


  login(formData: any) {
    // return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData).pipe(
      tap(() => {
        this.getUserProfile().subscribe(
          () => {
            // User profile retrieved successfully, userName$ will be updated automatically
          },
          (error: any) => {
            console.log(error);
          }
        );
      })
    );
  }

  getUserProfile() {
    // let token = new HttpHeaders({'Authorization':'Bearer ' + localStorage.getItem('token')})
    // return this.http.get(this.BaseURI + '/UserProfile');
    return this.http.get(this.BaseURI + '/UserProfile').pipe(
      tap((res: any) => {
        this.fullNameSubject.next(res.userName);
      })
    );
  }

  setLoggedIn(isLoggedIn: boolean): void {
    this.isLoggedInSubject.next(isLoggedIn);
  }


  deleteProfile(userId: string) {
    return this.http.delete(`${this.BaseURI}/ApplicationUser/Delete/${userId}`);
  }

  setFullName(fullName: string): void {
    this.fullNameSubject.next(fullName);
  }

  setUserId(userId: string): void {
    this.userIdSubject.next(userId);
  }
}

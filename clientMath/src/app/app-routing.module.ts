import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";

import {AuthGuard} from "./_guards/auth.guard";
import {TestErrorComponent} from "./errors/test-error/test-error.component";
import {NotFoundComponent} from "./errors/not-found/not-found.component";
import {ServerErrorComponent} from "./errors/server-error/server-error.component";
import {UserComponent} from "./user/user/user.component";
import {RegistrationComponent} from "./user/registration/registration/registration.component";
import {LoginComponent} from "./user/login/login.component";
import {DummyComponent} from "./dummy/dummy.component";
import {ShowUserProfileComponent} from "./user/show-user-profile/show-user-profile.component";
import {DeleteProfileComponent} from "./user/delete-profile/delete-profile.component";
import {EditUserComponent} from "./user/edit-user/edit-user.component";
import {QuizComponent} from "./q/quiz/quiz.component";
import {ResultComponent} from "./q/result/result.component";

const routes: Routes = [
  {path: '', redirectTo: "/user/login", pathMatch: 'full'},
  {
    path: "user", component: UserComponent,
    children: [
      {path: "registration", component: RegistrationComponent},
      {path: "login", component: LoginComponent}
    ]
  },
  {path:'dummy', component:DummyComponent},
  {path:'home', component:HomeComponent, canActivate:[AuthGuard]},
  {path:'showUserInfo', component:ShowUserProfileComponent, canActivate:[AuthGuard]},
  {path:'deleteProfile', component:DeleteProfileComponent, canActivate:[AuthGuard]},
  {path:'editUser', component:EditUserComponent, canActivate:[AuthGuard]},
  {path:'quiz', component:QuizComponent, canActivate:[AuthGuard]},
  {path:'result', component:ResultComponent, canActivate:[AuthGuard]}

];

//  [
//   {path: '', component: HomeComponent},
//   {path: '',
//     runGuardsAndResolvers: 'always',
//     canActivate: [AuthGuard],
//     children: [
//       {path: 'members', component: MemberListComponent},
//       {path: 'members/:id', component: MemberDetailComponent},
//     ]
//   },
//   {path: 'errors', component: TestErrorComponent},
//   {path: 'not-found', component: NotFoundComponent},
//   {path: 'server-error', component: ServerErrorComponent},
//   {path: '**', component: NotFoundComponent, pathMatch: 'full'}
// ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

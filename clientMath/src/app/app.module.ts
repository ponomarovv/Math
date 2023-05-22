import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";

import {NavComponent} from './nav/nav.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HomeComponent} from './home/home.component';

import {SharedModule} from "./_modules/shared.module";
import {TestErrorComponent} from './errors/test-error/test-error.component';
import {ErrorInterceptor} from "./_interceptors/error.interceptor";
import {NotFoundComponent} from './errors/not-found/not-found.component';
import {ServerErrorComponent} from './errors/server-error/server-error.component';
import {QuestionComponent} from './q/question/question.component';
import {QuestionsListComponent} from './q/questions-list/questions-list.component';
import {DummyComponent} from './dummy/dummy.component';
import {UserComponent} from './user/user/user.component';
import {RegistrationComponent} from './user/registration/registration/registration.component';
import {LoginComponent} from './user/login/login.component';
import {UserService} from "./_services/user.service";
import {AuthInterceptor} from "./_guards/auth.interceptor";
import { ShowUserProfileComponent } from './user/show-user-profile/show-user-profile.component';
import { DeleteProfileComponent } from './user/delete-profile/delete-profile.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { QuizComponent } from './q/quiz/quiz.component';
import { ResultComponent } from './q/result/result.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    QuestionComponent,
    QuestionsListComponent,
    DummyComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    ShowUserProfileComponent,
    DeleteProfileComponent,
    EditUserComponent,
    QuizComponent,
    ResultComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
    // {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

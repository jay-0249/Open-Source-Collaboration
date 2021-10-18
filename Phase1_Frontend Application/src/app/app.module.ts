import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectDashboardComponent } from './project-dashboard/project-dashboard.component';
import { NewProjectComponent } from './new-project/new-project.component';

//We have import services, interfaces in app.module.ts as
//1) to make them available to all 
//2) CLI doesn't update the app.module.ts when the services/interfaces/classes are created 
import { ProjectsService } from './Services/projects.service';
import { Project } from './Models/project';
import { UserService } from './Services/user.service';
import { User } from './Models/user';
import { ExtendedUser } from './Models/extended-user';

//We have to import the HTTP Client Module when we have to make http requests via services
import { HttpClientModule } from '@angular/common/http'

//To build reactive forms we need to import ReactiveFormsModule in the root or shared module
import { ReactiveFormsModule } from '@angular/forms';
//Pipes and Components are updated directly by CLI when created
import { NotAvailablePipe } from './pipes/not-available.pipe';
//FormsModule exports the providers and required for template-driven forms
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { HomeComponent } from './home/home.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { WelcomeComponent } from './welcome/welcome.component';
//import { HttpParams } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ProjectDashboardComponent,
    NewProjectComponent,
    NotAvailablePipe,
    LoginComponent,
    SignUpComponent,
    ForgotPasswordComponent,
    HomeComponent,
    UserProfileComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    //Add the imported modules
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    //HttpParams
  ],
  //Add the services in the providers list
  providers: [ProjectsService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }

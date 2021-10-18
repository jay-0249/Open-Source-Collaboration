import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NewProjectComponent } from './new-project/new-project.component';
import { ProjectDashboardComponent } from './project-dashboard/project-dashboard.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {path:'projectDashboard', component:ProjectDashboardComponent},
  {path:'newProject',component:NewProjectComponent},
  //{path:'',redirectTo:'home',pathMatch:'full'},
  {path:'signup',component:SignUpComponent},
  {path:'login', component:LoginComponent},
  {path:'home',component:HomeComponent},
  {path:'',redirectTo:'projectDashboard',pathMatch:'full'},
  {path:'forgotPassword',component:ForgotPasswordComponent},
  {path:'userProfile',component:UserProfileComponent},
  {path:'welcome',component:WelcomeComponent}
  //{path:'',redirectTo:'newProject',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../Models/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  profileoverview=true;
  projects=false;
  contact=false;
  
  UsernameActive="jay";
  PDescription="Profile overview";
  userActive:User= new User();
  isUserActive=false;

  email="sample@gamil.com";
  gihubprofile="sample113";
  gitlabprofile="sample3523";

  projectTitle="Project 1";
  description="Description about project";


  constructor(private _userService:UserService, _router:Router) { }

  ngOnInit(): void {
    //this.UsernameActive=this._userService.GetUsername();
    
    this._userService.getUserDetails().subscribe((data:User)=>{
          this.userActive=data;
          this.UsernameActive=this.userActive.username;
          console.log(this.UsernameActive);
          console.log(this.userActive);
    });
  }

  overviewdisplay()
  {
    this.profileoverview=true;
    this.projects=false;
    this.contact=false;
    // console.log(this.profileoverview+""+this.projects+""+this.contact);
  }
  projectsdisplay(){
    this.profileoverview=false;
    this.projects=true;
    this.contact=false;
    // console.log(this.profileoverview+""+this.projects+""+this.contact);
  }
  contactsdispaly(){
    this.profileoverview=false;
    this.projects=false;
    this.contact=true;
    // console.log(this.profileoverview+""+this.projects+""+this.contact);
  }


  getUserDetails(){
    this._userService.getUserDetails().subscribe((data:User)=>{
      this.userActive=data;
      this.UsernameActive=this.userActive.username;
      console.log(this.UsernameActive);
      console.log(this.userActive);
    });
  }
}

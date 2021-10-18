import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl } from '@angular/forms';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  // templateUrl: './sign-up.component.html',
  // styleUrls: ['./sign-up.component.scss']
  templateUrl: './signupDashboard.html',
  styleUrls: ['./signupDashboard.scss']
})
export class SignUpComponent implements OnInit {
  signupForm=new FormGroup({
    username:new FormControl(),
    email:new FormControl(),
    password:new FormControl(),
    confirmpassword:new FormControl()
   });
   user:User = new User();
   SignUpSuccess:string='User Signup succesfull';
   UserAlreadyExists:string='User Already Exists';
   signupResult:string='This string is not assigned with any signup response string yet';
   passwordMatchwithConfirm:Boolean = false;
   signupErrorString: string = ''; 
  constructor(private _router:Router, private _userService:UserService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    console.log(this.signupForm.value);
    const username= this.signupForm.value.username;
    const email = this.signupForm.value.email;
    const password = this.signupForm.value.password;
    const confirmpassword= this.signupForm.value.confirmpassword;
    console.log(username+" is username");
    console.log(email+" is email");
    console.log(password+" is password");
    console.log(confirmpassword+" is confirmpassword");
    if(password.toString() == confirmpassword.toString())
    {
      console.log("Password and confirm password match");
      this.user.username=username;
    this.user.contactMail=email;
    this.user.password=password;
    
    
    this._userService.addNewUser(this.user).subscribe((res:any)=>{
          this.signupResult = res.responseMessage;
          console.log(" In SignUp component, "+this.signupResult + "This is the SignUpResult");
     
          if(this.signupResult==this.SignUpSuccess){
            const flag = this._userService.SetUserToActive();
            console.log("User set to Active and the IsActive status is "+flag);
            const usernameActive = this._userService.SetUsername(username);
            console.log("Username of active User is set  as signup is successful and the username is "+usernameActive);
            this._router.navigate(['projectDashboard']);
          }
          else if(this.signupResult==this.UserAlreadyExists){
            const flag = this._userService.SetUserToInActive();
            console.log("User already and the IsActive status is "+flag);
            this.signupErrorString="User with this username and email id already exists";
          }
          else{
            console.log("the response from web api is not matching with our check strings, please check if there is any response strings are changed or any internal server error")
          }
        this.signupForm.reset();
    })
    }
    else{
      console.log("Password and confirm password doesn't match");
      this.signupErrorString="Password and Confirm Password doesn't match";
    }
    
  }

}

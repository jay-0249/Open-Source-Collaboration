import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl } from '@angular/forms';
import { UserService } from '../Services/user.service';
import { User } from '../Models/user';
import { take } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  //templateUrl: './login.component.html',
  templateUrl: './loginDashboard.html',
  //styleUrls: ['./login.component.scss']
  styleUrls: ['./loginDashboard.scss']
})
export class LoginComponent implements OnInit  {
  loginForm=new FormGroup({
    email:new FormControl(),
    password:new FormControl()
   });

   user:User = new User();
   loginResult:string='This string is not assigned with any response string yet';
   loginSucess: string='Successful Login';
   loginPasswordWrong: string='UnSuccessful Login';
   loginUsernameNotFound: string ="username invalid";
   loginErrorString: string = ''; 
  constructor(private _userService:UserService, private _router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    const username = this.loginForm.value.email;
    const password = this.loginForm.value.password;
    console.log(username+" is username");
    console.log(password+" is password");
    // this._userService.AreUsernamePasswordMatching(email,password).subscribe((data:string)=>console.log(data+" is the response"));
    // console.log(this.loginResult+" is the response from login");
    // const resultInLoginForm = this._userService.AreUsernamePasswordMatching(email,password);
    // resultInLoginForm.pipe(take(1)).subscribe(res=> {console.log('parsed json'+JSON.parse(res))});
    let user1:User = new User();
    user1.username= username;
    user1.password= password;
    this._userService.LoginwithUser(user1).subscribe((data:any)=>
                  {this.loginResult=data.responseMessage;
                    console.log(" In login component, "+this.loginResult + "This is loginResult");
    if(this.loginResult==this.loginSucess){
      const flag = this._userService.SetUserToActive();
      console.log("User set to Active and the IsActive status is "+flag);
      const usernameActive = this._userService.SetUsername(username);
      console.log("Username of active User is set  as login is successful and the username is "+usernameActive);
      this._router.navigate(['projectDashboard']);
    }
    else if(this.loginResult==this.loginPasswordWrong){
      const flag = this._userService.SetUserToInActive();
      console.log("User set to InActive and the IsActive status is "+flag);
      this.loginErrorString="Incorrect Password";
    }
    else if(this.loginResult== this.loginUsernameNotFound){
      const flag = this._userService.SetUserToInActive();
      console.log("username is not found and the IsActive status is "+flag);
      this.loginErrorString="Please enter a valid username";
    }
    else{
      console.log("the response from web api is not matching with our check strings, please check if there is any response strings are changed or any internal server error")
    }

    // if(this.loginResult.includes(this.loginUsernameNotFound)){
    //   const flag = this._userService.SetUserToInActive();
    //   console.log("username is not found and the IsActive status is "+flag);
    // }
    // else if(this.loginResult.includes(this.loginPasswordWrong)){
    //   const flag = this._userService.SetUserToInActive();
    //   console.log("User set to InActive and the IsActive status is "+flag);
    // }
    // else if(this.loginResult.includes(this.loginSucess)){

    //   const flag = this._userService.SetUserToActive();
    //   console.log("User set to Active and the IsActive status is "+flag);
    // }
    // else{
    //   console.log("("+this.loginResult+")");
    //   console.log("("+this.loginSucess+")");
    //   console.log("the response from web api is not matching with our check strings, please check if there is any response strings are changed or any internal server error")
    // }

     this.loginForm.reset();
    // const isUserActive = this._userService.extendedUserObj.IsUserActive;
    // if(isUserActive)
    // {
    //   this._router.navigate(['projectDashboard']);
    // }
    // else{
    //   this._router.navigate(['login']);
    // }
  })
  }

}

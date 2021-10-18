import { Injectable } from '@angular/core';
//imports added
import { HttpClient} from '@angular/common/http';
//import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user';
import { ExtendedUser } from '../Models/extended-user';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  extendedUserObj:ExtendedUser = new ExtendedUser();
  user1:User = new User();
  usernameActive:string = 'This string is not assigned with any signup response string yet';
  userServiceURL = "https://localhost:44368/api/Users";
  constructor(private httpClient:HttpClient) { }
  
  //GetUserDetails Function
  public getAllUserDetails() : Observable<User[]>
  {
    // let getAllProjectsURL : string = this.getUrl+'/api/Projects' ;
    //return this.httpClient.get<User[]>('https://localhost:44368/api/Users');
    return this.httpClient.get<User[]>(this.userServiceURL);
  }

  //Get a soecific user details using username of the user
  public getUserDetails() : Observable<User>
  {
    // let getAllProjectsURL : string = this.getUrl+'/api/Projects' ;
    //return this.httpClient.get<User[]>('https://localhost:44368/api/Users');
    //let paramsList = new HttpParams().append('username',username);
    console.log(this.usernameActive+'is the username of active user currently');
    return this.httpClient.get<User>(this.userServiceURL+'/'+this.usernameActive);
  }
  
  //SignUp Function
  addNewUser(user:User): Observable<User> {
    // perform the appropriate API call here that will add a project to the server
    //https://localhost:44368/api/Users/SignUp
    let signUpURL:string = this.userServiceURL+'/SignUp';
    return this.httpClient.post<User>(signUpURL,user);
  } 

        //Login Function
        //username:string, password:string
  AreUsernamePasswordMatching(username:string, password:string):Observable<any>{
    console.log(username+" is username");
    console.log(password+" is password");
        let loginURL:string = this.userServiceURL+'/login';
        //loginURI:string =this.userServiceURL+'/login?username=jay&password=password';
        //let paramsList = new HttpParams().set('username',username).set('password',password);
        //return this.httpClient.post<string>(loginURL, {paramsList});
    //let loginURI:string = (this.userServiceURL+"/login?username="+username+"&password="+password).toString();
     let result:any = this.httpClient.post<any>(loginURL,{username,password});
     let result1:any = this.httpClient.post<any>(loginURL,{username,password},{observe:'response'});
     console.log(result+" is result");
     let body = JSON.stringify(result);
     console.log(body+" is body");

     let result2 = encodeURI(JSON.stringify(result));
     console.log(result2+" is result2");
    return result1;
        //,username,password
    }

    LoginwithUser(user:User):Observable<any>{
      let loginURL:string = this.userServiceURL+'/loginInputUser';
     var result = this.httpClient.post<any>(loginURL,user);
     console.log(result);
     return result;
    }

  //Set IsActive Property to True after Login, SignUp
  SetUserToActive():boolean{
    console.log("Before calling function "+this.extendedUserObj.IsUserActive);
    this.extendedUserObj.IsUserActive=true;
    console.log("After calling function "+this.extendedUserObj.IsUserActive);
    return this.extendedUserObj.IsUserActive;
  }
  //Set IsActive Property to False after Logout
   SetUserToInActive():boolean{
    this.extendedUserObj.IsUserActive=false;
    return this.extendedUserObj.IsUserActive;
  }
  //To set the username of active user
  SetUsername(name:string):string{
    this.usernameActive = name;
    return this.usernameActive;
  }
  //Get IsActive property
  GetUserStatus(){
    console.log("GetUserStatus is called to fetch the IsActive variable");
    return  this.extendedUserObj.IsUserActive;
  }
  GetUsername():string{
    return this.usernameActive;
  }
}



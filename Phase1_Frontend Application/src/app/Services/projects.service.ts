import { Injectable } from '@angular/core';
//imports added
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../Models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  getUrl:string = '';
  constructor(private httpClient:HttpClient) { }

  
  public getAllProjects() : Observable<Project[]>
  {
    // let getAllProjectsURL : string = this.getUrl+'/api/Projects' ;
    return this.httpClient.get<Project[]>('https://localhost:44368/api/Projects');
    //return this.httpClient.get<>('https://localhost:44368/WeatherForecast');
  }

  public getProjectsSearched(keywordSearched:string) : Observable<Project[]>
  {
    // let getAllProjectsURL : string = this.getUrl+'/api/Projects' ;
    return this.httpClient.get<Project[]>('https://localhost:44368/api/Projects'+'/'+keywordSearched);
    //return this.httpClient.get<>('https://localhost:44368/WeatherForecast');
  }

  public getAll() : Observable<string>
  {
    // let getAllProjectsURL : string = this.getUrl+'/api/Projects' ;
    //return this.httpClient.get<Project[]>('https://localhost:44368/api/Projects');
    return this.httpClient.get<string>('https://localhost:44368/WeatherForecast');
  }

  addProject(project: Project): Observable<Project> {
    // perform the appropriate API call here that will add a project to the server
    let myURL:string = 'https://localhost:44368/api/Projects/AddProject';
    return this.httpClient.post<Project>(myURL,project);
  } 
}

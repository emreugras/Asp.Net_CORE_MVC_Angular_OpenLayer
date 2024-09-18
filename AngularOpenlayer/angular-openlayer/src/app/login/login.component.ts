import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { HttpClientService } from '../http-client.service';

import { Observable, firstValueFrom } from 'rxjs';
import { TokenResponse } from './TokenResponse';
import { RouteReuseStrategy, Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
constructor(private userService:UserService,private router:Router){}
ngOnInit(): void {

}


async login(Uname:string,Upswd:string,callBackFunction?: ()=>void):Promise<any>{
  
  const observable:Observable<any | TokenResponse>= this.userService.post<any | TokenResponse>({
    fullEndPoint:"https://localhost:7173/api/user/login"
  },{
    Name:Uname,
    Password:Upswd
  })
 

const TokenResponse:TokenResponse= await firstValueFrom(observable) as TokenResponse;
if(TokenResponse!=null){
 debugger;
  localStorage.setItem("accessToken",TokenResponse.token.accessToken)
this.router.navigate(["layer"]);
}
  
  


  
  
}


}

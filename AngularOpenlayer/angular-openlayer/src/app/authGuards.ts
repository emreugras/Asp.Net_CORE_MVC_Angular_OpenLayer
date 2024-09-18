import { Injectable, inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
@Injectable({
    providedIn:'root'
  })

export class authGuards implements CanActivate{
  constructor(private jwtHelper:JwtHelperService,private router:Router){}
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
     


    const token:string=localStorage.getItem("accessToken");
   // const decodeToken= inject(JwtHelperService).decodeToken(token);
   // const expirationDate= inject(JwtHelperService).getTokenExpirationDate(token);
   let expired:boolean;
   try {
    debugger;
     expired=this.jwtHelper.isTokenExpired(token);
   } catch {
     expired=true;
   }
    
   if (!token || expired) {
     this.router.navigate(["login"],{queryParams:{returnUrl :state.url}});
     return false;
   
   }
   debugger;
     return true;
   };
  }





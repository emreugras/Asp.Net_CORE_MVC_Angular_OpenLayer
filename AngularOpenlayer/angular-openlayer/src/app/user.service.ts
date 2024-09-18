import { Inject, Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Observable, firstValueFrom } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ErrorHandler } from '@angular/core';
declare var $:any
@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClient:HttpClient,@Inject("baseUrl") private baseUrl:string) {}

  private url(requestParameter:Partial<RequestParameters>):string{
    return `${requestParameter.baseurl?requestParameter.baseurl:this.baseUrl}/${requestParameter.controller}${requestParameter.action ?`/${requestParameter.action}`:""}`;
  }
  
  
    post<T>(requestParameter:Partial<RequestParameters>,body:Partial<T>):Observable<T>{
      let url:string="";
      errorHandler:ErrorHandler
      if(requestParameter.fullEndPoint){
        url=requestParameter.fullEndPoint;
      }else{
        url=`${this.url(requestParameter)}`;
      
      }
      return this.httpClient.post<T>(url,body,{headers:requestParameter.headers});
    }

}

export class RequestParameters{
  controller?:string;
  action?:string;

  headers?:HttpHeaders;
  fullEndPoint?:string;
  baseurl?:string;
}
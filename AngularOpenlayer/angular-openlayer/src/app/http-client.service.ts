import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { toInteger } from '@ng-bootstrap/ng-bootstrap/util/util';
import { get } from 'ol/proj';
import { Observable, catchError, throwError } from 'rxjs';
import { ErrorHandler } from '@angular/core';
declare var $:any

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private httpClient:HttpClient,@Inject("baseUrl") private baseUrl:string) {}

  private url(requestParameter:Partial<RequestParameters>):string{
    return `${requestParameter.baseurl?requestParameter.baseurl:this.baseUrl}/
    ${requestParameter.controller}${requestParameter.action ?`/${requestParameter.action}`:""}`;
  }


get<T>(requestParameter:Partial<RequestParameters>,id?:string):Observable<T>{
let url:string="";
if(requestParameter.fullEndPoint){
  url=requestParameter.fullEndPoint;
}else{
  url=`${this.url(requestParameter)}${id?`/${id}`:""}`;

}
return this.httpClient.get<T>(url,{headers:requestParameter.headers});
}
    
    post<T>(requestParameter:Partial<RequestParameters>,body:Partial<T>):Observable<T>{
      let url:string="";
      if(requestParameter.fullEndPoint){
        url=requestParameter.fullEndPoint;
      }else{
        url=`${this.url(requestParameter)}`;
      
      }
      return this.httpClient.post<T>(url,body,{headers:requestParameter.headers});
    }
  
//    delete<T>(requestParameter:Partial<RequestParameters>,id:string):Observable<T>{
// let url:string="";
// if(requestParameter.fullEndPoint){
// url=requestParameter.fullEndPoint;
// }else{
//   url=`${this.url(requestParameter)}/${id}`;
// }
// return this.httpClient.delete<T>(url,{headers:requestParameter.headers});
//    }
// }
delete(id){
  return this.httpClient.delete("https://localhost:7173/api/geometry"+'/'+id);
}

put<T>(requestParameter:Partial<RequestParameters>,body:Partial<T>):Observable<T>{
  let url:string="";
  errorHandler:ErrorHandler
  if(requestParameter.fullEndPoint){
    url=requestParameter.fullEndPoint;
  }else{
    url=`${this.url(requestParameter)}`;
  
  }
  return this.httpClient.put<T>(url,body,{headers:requestParameter.headers});
}


}
export class RequestParameters{
  controller?:string;
  action?:string;

  headers?:HttpHeaders;
  fullEndPoint?:string;
  baseurl?:string;
}
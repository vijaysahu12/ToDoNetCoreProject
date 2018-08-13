import { Injectable, Inject } from '@angular/core';
import { environment } from "../../environments/environment"
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError,tap, map } from  'rxjs/operators';
@Injectable()
export class ToDoService {
  myAppUrl: string = environment.url;
  
  constructor(private _http: HttpClient) {
 
  }
  getToDoList() : Observable<any> {
    return this._http.get<any>(this.myAppUrl)
      .pipe(
        tap(),
        catchError(this.handleError)
      );
  }  
 addToDoItem(newToDoItem:string):Observable<any>{

  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  let body ={
    content : newToDoItem,
    status : false
  };
  return this._http.post<string>(this.myAppUrl,body,httpOptions).pipe(tap(data=> console.log(JSON.stringify(data))),catchError(this.handleError));
 }

  deleteToDoItem(id:number){
    return this._http.delete(this.myAppUrl+"/"+id)
    .pipe(tap(data=> console.log(JSON.stringify(data))),
    catchError(this.handleError));
  }

  updateToDoStatus(id:number,content:string,status:any){
    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'my-auth-token'
      })
    };
    if(status == false){
      status = true;
    }else{
      status = false;
  }

    let body ={
      id: id,
      content: content,
      status :status,
    };
    

    return this._http.put<string>(this.myAppUrl,body,httpOptions)
    .pipe(tap(data=>console.log(JSON.stringify(data))),
    catchError(this.handleError));
  }


  handleError(error: Response) {
    console.log(error);
    return Observable.throw(error);
  } 
}

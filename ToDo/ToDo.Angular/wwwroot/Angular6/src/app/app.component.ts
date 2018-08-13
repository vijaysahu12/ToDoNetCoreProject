import { Component } from '@angular/core';
import { ToDoService } from './service/to-do.service'
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { IData,IResponseData } from './Models/ToDoListData.model'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ToDo';
  ToDoResponse : IResponseData;
  private dataList: IData[] = [];
  newToDoItem1 : string= "";


  ToDoForm : FormGroup;
  constructor(private _fb : FormBuilder, private _service : ToDoService ){

  this.ToDoForm = this._fb.group({
    ToDoId: 0,
    Content: new FormControl(),
    Status: new FormControl(),
  });

  this.getToDoList();
}

getToDoList(){
  this._service.getToDoList()
  .subscribe(res=> {
    this.ToDoResponse = res;
    this.dataList = this.ToDoResponse.data;
    if(this.ToDoResponse.statusCode != "200"){
      console.log("Internal server issues");
    }
  });
}//getToDoList end block 


addToDoData(newToDoItem:string){ 

  var resdfsd = this.newToDoItem1;
  if(newToDoItem.length >3){
    this._service.addToDoItem(newToDoItem).subscribe(res=>{
      this.getToDoList();
    });
  }
  else{
    alert("Please provide valid ToDo item");
  }
}


updateToDoStatus(id:number,content:string,status:any){

  
  this._service.updateToDoStatus(id,content,status).subscribe(response=>{
    console.log(response);
    this.getToDoList();
  });

}//update status end block

deleteToDoItem(id:number){
  this._service.deleteToDoItem(id).subscribe(response=>{
    console.log(response);
    this.getToDoList();
  });
}//Delete ToDO end block

}//class end block


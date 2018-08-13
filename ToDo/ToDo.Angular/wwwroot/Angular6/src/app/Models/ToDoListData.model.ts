import { identifierModuleUrl } from "../../../node_modules/@angular/compiler";

export interface IResponseData{
        data : IData[],
        statusCode:string;
        responseMessage:string;
}

export class IData2{
    private id:number;
    constructor(id) {
        this.id = id;
   }
}

export class IData{
    private id : number;  
    private content:string;  
    private status:boolean;  
    constructor(id,content,status) {
        this.id = id;
        this.content = content;
        this.status = content;
    }
}
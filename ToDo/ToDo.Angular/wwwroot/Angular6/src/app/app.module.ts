import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// import { AppRoutingModule } from './app-routing.module'
import {HttpClientModule} from '@angular/common/http'
import { AppComponent } from './app.component';
import { ToDoService } from './service/to-do.service';
import { FormsModule, ReactiveFormsModule } from '../../node_modules/@angular/forms';
import { HttpModule } from '../../node_modules/@angular/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    [BrowserModule,HttpClientModule,ReactiveFormsModule]
  ],
  providers: [ToDoService],
  bootstrap: [AppComponent]
})
export class AppModule { }

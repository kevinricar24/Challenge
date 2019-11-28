import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { ListEmployeeComponent } from './employee/list-employee/list-employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './employee/edit-employee/edit-employee.component';
import {ApiService} from "./service/api.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ListEmployeeComponent,
    AddEmployeeComponent,
    EditEmployeeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'list-employee', component: ListEmployeeComponent },
      { path: 'add-employee', component: AddEmployeeComponent },
      { path: 'edit-employee', component: EditEmployeeComponent },
    ])
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }

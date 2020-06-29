import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { CategoryService } from './_services/category.service';

import { from } from 'rxjs';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [
      CategoryService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

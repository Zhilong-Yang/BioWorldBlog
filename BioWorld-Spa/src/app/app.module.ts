import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { MDBSpinningPreloader } from 'ng-uikit-pro-standard';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { CategoryService } from './#services/category.service';
import { PostService } from './#services/post.service';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PostlistsComponent } from './postlists/postlists.component';
import { PostlistitemComponent } from './postlistitem/postlistitem.component';

import { PostListsResolver } from './#resolvers/postlists.resolver';
import {PostDetailResolver} from './#resolvers/postdetail.resolver';
import { ToastModule } from 'ng-uikit-pro-standard';
import { PostdetailComponent } from './postdetail/postdetail.component';

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      PostlistsComponent,
      PostlistitemComponent,
      PostdetailComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      AppRoutingModule,
      ToastModule.forRoot(),
      MDBBootstrapModulesPro.forRoot()
   ],
   providers: [
      MDBSpinningPreloader,
      CategoryService,
      PostService,
      PostListsResolver,
      PostDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

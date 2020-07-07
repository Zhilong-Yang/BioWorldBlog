import { BrowserModule } from '@angular/platform-browser';
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

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      PostlistsComponent,
      PostlistitemComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      MDBBootstrapModulesPro.forRoot()
   ],
   providers: [
      MDBSpinningPreloader,
      CategoryService,
      PostService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

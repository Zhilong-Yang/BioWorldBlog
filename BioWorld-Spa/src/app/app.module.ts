import { BrowserModule } from '@angular/platform-browser';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { MDBSpinningPreloader } from 'ng-uikit-pro-standard';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent
   ],
   imports: [
      BrowserModule,
      MDBBootstrapModulesPro.forRoot(),
      AppRoutingModule
   ],
   providers: [
      MDBSpinningPreloader
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

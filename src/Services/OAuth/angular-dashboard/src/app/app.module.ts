import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { declarations, routers } from './routers';
import { AppComponent } from './app.component';
import { services } from './services';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
   MatTableModule,
   MatButtonModule,
   MatCardModule,
   MatFormFieldModule,
   MatInputModule,
   MatProgressBarModule,
   MatToolbarModule ,
   MatProgressSpinnerModule,
   MatRadioModule,
   MatSliderModule
  } from '@angular/material'

@NgModule({
  declarations: declarations,
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressBarModule,
    MatToolbarModule ,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatSliderModule,
    MatTableModule,
    routers
  ],
  providers: services,
  bootstrap: [AppComponent]
})
export class AppModule { }

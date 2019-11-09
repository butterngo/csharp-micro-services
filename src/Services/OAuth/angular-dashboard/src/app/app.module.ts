import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientProvider } from '../app/http-client';
import { declarations, routers } from './routers';
import { AppComponent } from './app.component';

declarations.push(AppComponent)

@NgModule({
  declarations: declarations,
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    routers
  ],
  providers: [HttpClientProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }

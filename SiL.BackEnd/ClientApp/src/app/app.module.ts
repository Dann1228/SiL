// 初始化Module
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// UI Component Module
import { UIComponentsModule } from './UIComponents/UIComponents.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VideoRoomComponent } from './Pages/entertainment/video-room/video-room.component';

// routing Module
import { EntertainmentModule } from './Pages/entertainment/entertainment.module';

//common components
import { CommonComponentsModule } from './CommonComponents/commonComponents.module';

import { ApiModule, BASE_PATH } from '../app/APIServices';

@NgModule({
  declarations: [
    AppComponent,
    VideoRoomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    UIComponentsModule,
    NgbModule,
    EntertainmentModule,
    CommonComponentsModule,
    ApiModule,
    HttpClientModule
  ],
  providers: [{provide: BASE_PATH, useFactory: getBaseUrl }],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  var url = document.getElementsByTagName('base')[0].href;
  return url.substring(0,url.length-1);
}

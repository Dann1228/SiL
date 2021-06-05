import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { EntertainmentRoutingModule } from './entertainment-routing.module';

//component
import { VideoListComponent } from './video-list/video-list.component';

//material ui
import {MatCardModule} from '@angular/material/card';

//common components
import {CommonComponentsModule} from '../../CommonComponents/commonComponents.module';

@NgModule({
  declarations: [
    VideoListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    EntertainmentRoutingModule,
    CommonComponentsModule,
  ],
  providers: [
    // {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
    // {provide: MAT_DATE_FORMATS, useValue: MY_FORMATS},
    // {provide: MAT_DATE_LOCALE, useValue: 'zh-tw'},
  ]
})
export class EntertainmentModule { }

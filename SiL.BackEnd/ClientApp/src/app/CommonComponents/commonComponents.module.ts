
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VideoPlayerComponent } from './video-player/video-player.component';

import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    VideoPlayerComponent,
  ],
  imports: [
    CommonModule,
    NgbModule,
    MatButtonModule
  ],
  exports:[
    VideoPlayerComponent,
  ]
})
export class CommonComponentsModule { }

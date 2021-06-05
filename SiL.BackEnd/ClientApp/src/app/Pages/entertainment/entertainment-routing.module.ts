import { NgModule } from '@angular/core';
//import { AuthGuard } from './../../Setting/authguard';
import { RouterModule, Routes } from '@angular/router';
import { VideoListComponent } from './video-list/video-list.component';
import { VideoRoomComponent } from './video-room/video-room.component';

const routes: Routes = [
  {
    path: '',
    //canActivate:[AuthGuard],
    children: [
      {
        path: 'entertainment',
        children: [
          {
            path: 'videolist',
            component: VideoListComponent,
            data: {
              breadcrumb: [
                {
                  label: '影片',
                  url: ''
                },
              ]
            },
          },
          {
            path: 'videoroom/:id',
            component: VideoRoomComponent,
            data: {
              breadcrumb: [
                {
                  label: '影院',
                  url: ''
                },
              ]
            },
          }
        ]
      }
    ]
  }

];
export const EntertainmentRoutingModule = RouterModule.forChild(routes);

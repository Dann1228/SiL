import { VideoService } from './../../APIServices/api/video.service';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import videojs from 'video.js';

@Component({
  selector: 'app-video-player',
  templateUrl: './video-player.component.html',
  styleUrls: ['./video-player.component.scss']
})
export class VideoPlayerComponent implements OnInit {

  constructor(private videoService: VideoService,
              private sanitizer: DomSanitizer) { }

  @Input() source: any = "";


  ngOnInit(): void {
  }

  onPlay(): void{
    this.videoService.apiVideoSampleVideoStreamGet().subscribe(rs => {
      var blobUrl = window.URL.createObjectURL(rs);
      this.source = this.sanitizer.bypassSecurityTrustUrl(blobUrl);
    });
  }
  sanitize(url: string) {
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }
}

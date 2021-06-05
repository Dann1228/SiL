import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'ClientApp';
  isOpenMenu: boolean = true;

  onMenuClick(): void{
    this.isOpenMenu = !this.isOpenMenu;
  }

}

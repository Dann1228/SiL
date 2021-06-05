import { MenuItem, MenuItems } from '../../Models/menu/menuItem';
import { Component, OnInit, Input, ChangeDetectorRef} from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  private _mobileQueryListener: () => void;
  private _showIcon: string = "arrow_forward_ios"; //選單縮合按鈕icon代碼 - 展開時
  private _hideIcon: string = "arrow_back_ios";//選單縮合按鈕icon代碼 - 收縮時
  @Input() isOpenMenu: boolean = true;
  mobileQuery: MediaQueryList; //用以判斷是否為手機/電腦板
  menuItems : MenuItem[] = []; //選單
  isShowHideButton: boolean = !this.isOpenMenu; //是否顯示選單縮合按鈕
  showHideButtonIcon: string = this.isOpenMenu ? this._hideIcon: this._showIcon; //顯示的選單縮合按鈕icon代碼

  constructor(media: MediaMatcher, changeDetectorRef: ChangeDetectorRef) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // tslint:disable-next-line: deprecation
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit(): void {
    this.menuItems = MenuItems;
  }

  //點選選單縮合按鈕
  onMenuClick(): void{
    this.isOpenMenu = !this.isOpenMenu;
    this.showHideButtonIcon = this.isOpenMenu ? this._hideIcon: this._showIcon;
  }

  //當滑鼠於選單上
  onMenuHover(): void{
    this.isShowHideButton = true;
  }

  //當滑鼠離開於選單上
  onMenuLeave():  void{
    this.isShowHideButton = false;
  }
}

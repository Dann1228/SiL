/**
 * 選單資料
 */
 export interface MenuItem {
  /**
   * 名稱
   */
  title?: string;
  /**
   * 圖示
   */
  icon?: string;
  /**
   * 連結
   */
  link?: string;
  /**
   * 子選單
   */
  children?: Array<MenuItem>;
}

export const MenuItems: MenuItem[] = [
  {
    title: '影音娛樂',
    icon: 'video_library',
    children: [
      {
        title: '連續劇',
        icon: 'description',
        children: [
          {
            title: '更新推薦',
            icon: 'how_to_reg',
            link: '/entertainment/videolist'
          }
        ]
      },
      {
        title: '電影',
        icon: 'description',
        children: [
          {
            title: '個人待辦事項',
            icon: 'person',
            link: '/eventprocess/eventtodo'
          },
          {
            title: '個人簽核歷程',
            icon: 'person',
            link: '/eventprocess/eventall'
          },
          {
            title: '單位待辦事項',
            icon: 'class',
            link: '/eventprocess/uniteventtodo'
          },
          {
            title: '單位簽核歷程',
            icon: 'class',
            link: '/eventprocess/uniteventall'
          },
        ]
      },
      {
        title: '動漫',
        icon: 'description',
        children: [
          {
            title: '事件查詢',
            icon: 'local_library',
            link: '/eventprocess/eventsearch'
          },
          {
            title: '事件監控',
            icon: 'local_library',
            link: '/eventprocess/eventmonitor'
          }
        ]
      },
    ]
  },
  {
    title: '系統管理',
    icon: 'ballot',
    children: [
      {
        title: '使用者管理維護',
        icon: 'group',
        children: [
          {
            title: '使用者管理維護',
            icon: 'group',
            link: '/user'
          },
          {
            title: '權限設定',
            icon: 'waves',
            link: '/role'
          },
        ]
      },
      {
        title: '最新消息維護', // added by David 新增最新消息於menu列
        icon: 'group',
        children: [
          {
            title: '最新消息維護',
            icon: 'group',
            link: '/news'
          }
        ]
      },
      {
        title: '系統環境設定',
        icon: 'group',
        children: [
          {
            title: '全域參數設定',
            icon: 'search',
            link: '/codemap'
          },
          {
            title: '系統環境參數設定',
            icon: 'search',
            link: '/systemconfig'
          }
        ]
      },
      {
        title: '操作紀錄', // added by Eve 新增操作紀錄於menu列
        icon: 'group',
        children: [
          {
            title: '操作紀錄',
            icon: 'search',
            link: '/motionlog'
          },
        ]
      },
    ]
  },
  {
    title: '共用元件',
    icon: 'desktop_windows',
    children: [
      {
        title: '共用元件',
        icon: 'description',
        children: [
          {
            title: '共用提示訊息',
            icon: 'how_to_reg',
            link: '/commoncomponents/message'
          },
          {
            title: '共用附件',
            icon: 'how_to_reg',
            link: '/commoncomponents/attachment'
          },
          {
            title: '共用Modal',
            icon: 'how_to_reg',
            link: '/commoncomponents/modal'
          },
        ]
      },
    ]
  },
];

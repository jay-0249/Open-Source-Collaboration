import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  //templateUrl: './home.component.html',
  templateUrl: './homeworking.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    searchString:string ="";
  constructor() { }
  isSideMenuOpen:boolean= true;
  isProfileMenuOpen:boolean = true;
  isPagesMenuOpen:boolean = true;
  isModalOpen:boolean= true;
  trapCleanup= null;
  ngOnInit(): void {
  }

  closeProfileMenu() {
    this.isProfileMenuOpen = false;
  }
  
  toggleProfileMenu() {
      this.isProfileMenuOpen = !this.isProfileMenuOpen;
  }

  toggleSideMenu() {
    this.isSideMenuOpen = !this.isSideMenuOpen
  }
  closeSideMenu() {
      this.isSideMenuOpen = false
  } 
  togglePagesMenu() {
      this.isPagesMenuOpen = !this.isPagesMenuOpen
  }
  // Modal
  
  openModal() {
      this.isModalOpen = true
      this.trapCleanup = focusTrap(document.querySelector('#modal'))
  }
  closeModal() {
      this.isModalOpen = false
      if(this.trapCleanup)
      {
        this.trapCleanup;
      }
      
  }
   data() {
    function getThemeFromLocalStorage() {
        if (window.localStorage.getItem('dark')) {
            return JSON.parse(window.localStorage.getItem('dark')!)
        }


        return (!!window.matchMedia &&
            window.matchMedia('(prefers-color-scheme: dark)').matches
        )
    }

    function setThemeToLocalStorage(value: string) {
        window.localStorage.setItem('dark', value)
    }

    return {
        dark: getThemeFromLocalStorage(),
        toggleTheme() {
            this.dark = !this.dark
            setThemeToLocalStorage(this.dark)
        },
        isSideMenuOpen: false,
        toggleSideMenu() {
            this.isSideMenuOpen = !this.isSideMenuOpen
        },
        closeSideMenu() {
            this.isSideMenuOpen = false
        },
        isNotificationsMenuOpen: false,
        // toggleNotificationsMenu() {
        //     this.isNotificationsMenuOpen = !this.isNotificationsMenuOpen
        // },
        // closeNotificationsMenu() {
        //     this.isNotificationsMenuOpen = false
        // },
        isProfileMenuOpen: false,
        toggleProfileMenu() {
            this.isProfileMenuOpen = !this.isProfileMenuOpen
        },
        closeProfileMenu() {
            this.isProfileMenuOpen = false
        },
        isPagesMenuOpen: false,
        togglePagesMenu() {
            this.isPagesMenuOpen = !this.isPagesMenuOpen
        },
        // Modal
        isModalOpen: false,
        trapCleanup: null,
        openModal() {
            this.isModalOpen = true
            this.trapCleanup = focusTrap(document.querySelector('#modal'))
        },
        closeModal() {
            this.isModalOpen = false
            if(this.trapCleanup)
            {
              this.trapCleanup;
            }
            
        },
    }
}

}
function focusTrap(arg0: any): null {
  throw new Error('Function not implemented.');
}


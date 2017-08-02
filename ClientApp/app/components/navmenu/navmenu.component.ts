import { Component, Input } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
})
export class NavMenuComponent {
    @Input() menuItems: Array<any>;
    @Input() showLoadingAnimation: boolean;
    @Input() title: string;
}

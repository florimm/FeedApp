import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-description',
    template: `<div [innerHTML]="content"></div>`
})
export class FeedDescriptionComponent {
    @Input() content;
}

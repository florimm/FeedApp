import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-title',
    template: `<h4 class="title">{{title}}</h4>`,
    styles: [`
                .title {
                    font-size: 18x;
                    letter-spacing: 2px;
                    text-transform: uppercase;
                }
            `]
})
export class FeedTitleComponent {
    @Input() title;
}

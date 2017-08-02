import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-items',
    template: `<div class="container">
                <div class="row">
                    <masonry>
                        <feed-item *ngFor="let item of newsItems"
                            [newsItem]="item">
                        </feed-item>
                    </masonry>
                </div>
               </div>`,
})
export class FeedItemsComponent {
    @Input() newsItems: Array<any>;
}

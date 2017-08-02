import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-source-items',
    template: `<div class="container">
                <div class="row" >
                    <feed-source-item *ngFor="let item of sources"
                                    [source] = "item" >
                    </feed-source-item>
                </div>
               </div>`
})
export class FeedSourceItemsComponent {
    @Input() sources: Array<any>;
}

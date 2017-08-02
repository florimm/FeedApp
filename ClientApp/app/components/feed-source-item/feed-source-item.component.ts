import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-source-item',
    template: `<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                 <div class="box">
                    <div class="info">
                        <h4 class="text-center">{{source.name}}</h4>
                        <span>{{source.lastFetched}}</span>
                        <a href="{{source.url}}" target="blank" class="btn">Show</a>
                    </div>
                </div>
               </div>`,
    styles: [`.box {
            border-radius: 3px;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            padding: 10px 25px;
            text-align: right;
            display: block;
            margin-top: 60px;
        }
        .info h4 {
            font-size: 20px;
            letter-spacing: 2px;
            text-transform: uppercase;
        }`],
})
export class FeedSourceItemComponent {
    @Input() source: any;
}

import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-item',
    template: `<div class="box">
                <a href="{{newsItem.url}}" target="blank" class="box-link">
                    <div class="info">
                        <feed-title [title]="newsItem.title"></feed-title>
                        <feed-description [content]="newsItem.description"></feed-description>
                        <hr class="divider" />
                        <div class="footer">{{newsItem.source}} / {{newsItem.timestamp | date : "MMM d, h:mm a"}} / {{newsItem.category}}</div>
                    </div>
                </a>
            </div>`,
    styles: [
        `.box {
            display: inline-block;
    background: #f5f5f5;
    padding: 1.5em;
    margin: 0 0 1.5em;
    width: 100%;
    box-sizing: border-box;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-shadow: 0px 1px 1px 0px rgba(0, 0, 0, 1.18);
    border-radius: 3px;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
        }

        .info h4 {
            font-size: 20px;
            letter-spacing: 2px;
            text-transform: uppercase;
        }
        .footer {
            float:left;
            width:100%;
            margin-top:10px;
            color: #bebebe;
        }
        .divider {
            float: left;
            width: 100%;
            margin-top: 4px;
            margin-bottom: 0px;
        }
        .box-link,
        .box-link:hover {
           color: #000000;
           text-decoration: none;
        }
       `
    ],
})
export class FeedItemComponent {
    @Input() newsItem: any;
}

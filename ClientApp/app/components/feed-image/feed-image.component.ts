import { Component, Input } from '@angular/core';

@Component({
    selector: 'feed-image',
    template: `
        <a href="{{image.link}}">
            <img src="{{image.link}}" alt="{{image.title}}" />
        </a>`
})
export class FeedImageComponent {
    @Input() image;
}

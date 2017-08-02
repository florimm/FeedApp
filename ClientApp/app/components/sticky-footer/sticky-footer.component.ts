import { Component, Input } from '@angular/core';

@Component({
    selector: 'sticky-footer',
    template: `<footer class="footer">
                      <div class="container">
                        <p class="text-muted">{{description}}</p>
                      </div>
                </footer>`,
    styles: [`.footer {
    width: 100%;
    height: 60px;
    background-color: #222222;
    padding-top: 22px;
    color: #9b9a90;
}`]
})
export class StickyFooterComponent {
    @Input() description: string;
}
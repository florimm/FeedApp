import { Component } from '@angular/core';

@Component({
    selector: 'masonry',
    template: `<div class="wrapper">
                        <div class="wrapper">
                            <div class="masonry">
                                <ng-content></ng-content>
                            </div>
                        </div>
                </div>`,
    styles: [`
                .wrapper {
                    width: 95%;
                    margin: 1.5em auto;
                }
                
                @media only screen and (min-width: 1280px) {
                    .wrapper {
                        width: 1260px;
                    }
                }

                .masonry {
                    margin: 1.5em 0;
                    padding: 0;
                    -moz-column-gap: 1.5em;
                    -webkit-column-gap: 1.5em;
                    column-gap: 1.5em;
                    font-size: .85em;
                }

                @media only screen and (min-width: 700px) {
                    .masonry {
                        -moz-column-count: 2;
                        -webkit-column-count: 2;
                        column-count: 2;
                    }
                }

                @media only screen and (min-width: 900px) {
                    .masonry {
                        -moz-column-count: 3;
                        -webkit-column-count: 3;
                        column-count: 3;
                    }
                }

                @media only screen and (min-width: 1100px) {
                    .masonry {
                        -moz-column-count: 4;
                        -webkit-column-count: 4;
                        column-count: 4;
                    }
                }`]
})
export class MasonryComponent {}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from "rxjs/Observable";
import { LOAD_SOURCES, SAVE_SOURCE } from '../../actions/feed-sources.constants';
import { IAppState } from '../../store';
import * as models from '../../models';

@Component({
    selector: 'home-container',
    template: `<div class="home-container">
                    <feed-items [newsItems]="newsItems | async">
                    </feed-items>
               </div>`,
    styles: [`
    .home-container {
        padding-top: 50px;
        padding-bottom: 30px;
    }
    @media (max-width: 767px) {
        .home-container {
           padding-top: 0px;
        }
    }`],
})
export class HomeContainer implements OnInit {
    ngOnInit(): void {
        this.store.dispatch({ type: LOAD_SOURCES.REQUEST });
    }
    newsItems: Observable<Array<models.INewsItem>>;

    constructor(private store: Store<IAppState>, route: ActivatedRoute) {
        route.params.subscribe(routParam => {
            if (routParam.id) {
                this.newsItems = store.select(state => state.feedItems.items).map(newsItems => newsItems.filter(item => item.feedSourceId == routParam.id).sort(this.sortByDate));
            } else {
                this.newsItems = store.select(state => state.feedItems.items).map(newsItems => newsItems.sort(this.sortByDate));
            }
        });
        
    }

    refresh() {
        this.store.dispatch({ type: LOAD_SOURCES.REQUEST });
    }

    sortByDate(item1: models.INewsItem, item2: models.INewsItem) {
        let date1 = new Date(item1.timestamp);
        let date2 = new Date(item2.timestamp);

        if (date1 > date2) {
            return -1;
        } else if (date1 < date2) {
            return 1;
        } else {
            return 0;
        }
    }
}
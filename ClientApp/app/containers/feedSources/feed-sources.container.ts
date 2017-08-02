import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from "rxjs/Observable";
import { LOAD_SOURCES, SAVE_SOURCE } from '../../actions/feed-sources.constants';
import { IAppState } from '../../store';
import * as models from '../../models';

@Component({
    selector: 'feed-source-container',
    template: `<feed-source-items [sources]="sources | async">
               </feed-source-items>`
})
export class FeedSourcesContainer implements OnInit {
    ngOnInit(): void {
        this.store.dispatch({ type: LOAD_SOURCES.REQUEST });
    }
    sources: Observable<models.IFeedSource[]>;

    constructor(private store: Store<IAppState>){
        this.sources = store.select(state => state.feedSources.sources);
	}
}

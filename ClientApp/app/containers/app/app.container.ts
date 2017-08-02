import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from "rxjs/Observable";
import { LOAD_SOURCES, SAVE_SOURCE } from '../../actions/feed-sources.constants';
import { IAppState } from '../../store';
import * as models from '../../models';

@Component({
    selector: 'app',
    templateUrl: './app.container.html',
    styleUrls: ['./app.container.css']
})
export class AppContainer {
    sources: Observable<Array<any>>;
    loading: Observable<boolean>;
    
    constructor(private store: Store<IAppState>) {
        this.loading = store.select(state => state.ui.loading);
        this.sources = store.select(state => state.feedSources.sources)
            .map((items: models.IFeedSource[]) => items.map((item) => ({ name: item.name, id: item.id })));
    }
}

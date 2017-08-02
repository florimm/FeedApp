import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from "rxjs/Observable";
import { LOAD_SOURCES, SAVE_SOURCE } from '../../actions/feed-sources.constants';
import { IAppState } from '../../store';

@Component({
    selector: 'feed-source-input',
    templateUrl: './feed-source.input.component.html'
})
export class FeedSourceInputComponent {
    constructor(private store: Store<IAppState>){
        //this.sources = store.select(state => state.feedSources.sources);
	}
}

import { combineReducers, ActionReducer } from '@ngrx/store';
import * as fromRouter from '@ngrx/router-store';
import {
  sourcesReducer
} from './feed-sources.reducer';
import {
  itemsReducer
} from './feed-items.reducer';
import { IAppState } from '../store';

const reducers = {
  feedSources: sourcesReducer,
  feedItems: itemsReducer,
  router: fromRouter.routerReducer,
};

const combinedReducers: ActionReducer<IAppState> = combineReducers(reducers);

export function reducer(state: any, action: any) {
    return combinedReducers(state, action);
}
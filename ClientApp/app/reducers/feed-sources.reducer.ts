import { Action, ActionReducer } from '@ngrx/store';
import { SAVE_SOURCE, LOAD_SOURCES } from '../actions/feed-sources.constants';
import { IFeedSourcesState } from '../store';

const initialState: IFeedSourcesState = {
  sources: [ ],
};

export function sourcesReducer(state = initialState, action: Action): IFeedSourcesState {
  switch(action.type) {
    case SAVE_SOURCE.REQUEST:
      return Object.assign({}, state);
    case SAVE_SOURCE.SUCCESS:
      return Object.assign({}, state, {sources: [...state.sources, action.payload]});
    case SAVE_SOURCE.FAILURE:
      return Object.assign({}, state);
    case LOAD_SOURCES.REQUEST:
      return Object.assign({}, state);
    case LOAD_SOURCES.SUCCESS:
      return Object.assign({}, state, { sources: [...action.payload]});
    case LOAD_SOURCES.FAILURE:
    console.log('action', action.payload);
      return Object.assign({}, state);
    default:
      return state;
  }
}
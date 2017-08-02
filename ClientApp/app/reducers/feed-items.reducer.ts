import { Action, ActionReducer } from '@ngrx/store';
import { LOAD_ITEMS } from '../actions/feed-items.constants';
import { IFeedItemsState } from '../store';

const initialState: IFeedItemsState = {
  items: [],
};

export function itemsReducer(state = initialState, action: Action): IFeedItemsState {
  switch(action.type) {
      case LOAD_ITEMS.SUCCESS:
      const items = state.items.filter((item) => item.feedSourceId != action.payload.source.id);
      return Object.assign({}, state, { items: [...items, ...action.payload.items]});
    case LOAD_ITEMS.FAILURE:
      return Object.assign({}, state);// add error so we can display it
    default:
      return state;
  }
}